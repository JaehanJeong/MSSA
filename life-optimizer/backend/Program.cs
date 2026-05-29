using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Backend.Data;
using LifeOptimizer.Backend.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=lifeoptimizer.db"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalDev", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    EnsureNewTables(db);
    SeedDefaultData(db);
    CleanupOrphanedActiveQuests(db);
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });
}

app.UseCors("LocalDev");
app.UseAuthorization();
app.MapControllers();
app.Run();

static void EnsureNewTables(AppDbContext db)
{
    db.Database.ExecuteSqlRaw(@"
        CREATE TABLE IF NOT EXISTS Users (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Username TEXT NOT NULL,
            PasswordHash TEXT NOT NULL
        );
        CREATE TABLE IF NOT EXISTS Friendships (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            UserId INTEGER NOT NULL,
            FriendId INTEGER NOT NULL,
            Status TEXT NOT NULL DEFAULT 'Accepted',
            AcceptedAt TEXT NULL
        );
        CREATE TABLE IF NOT EXISTS SharedQuests (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            SenderId INTEGER NOT NULL,
            ReceiverId INTEGER NOT NULL,
            SenderUsername TEXT NOT NULL,
            Title TEXT NOT NULL,
            Stat TEXT NOT NULL,
            Rarity TEXT NOT NULL,
            XpReward INTEGER NOT NULL,
            SentAt TEXT NOT NULL,
            IsRead INTEGER NOT NULL DEFAULT 0
        );
    ");

    // Add columns to Friendships if upgrading from old schema (no-op if already present)
    TryExec(db, "ALTER TABLE Friendships ADD COLUMN Status TEXT NOT NULL DEFAULT 'Accepted'");
    TryExec(db, "ALTER TABLE Friendships ADD COLUMN AcceptedAt TEXT NULL");

    // Add UserId to QuestTemplates for per-user library ownership
    TryExec(db, "ALTER TABLE QuestTemplates ADD COLUMN UserId INTEGER NULL");

    // Add UserId to ActiveQuests for per-user dashboard
    TryExec(db, "ALTER TABLE ActiveQuests ADD COLUMN UserId INTEGER NULL");

    // Add UserId to Stats for per-user attributes
    TryExec(db, "ALTER TABLE Stats ADD COLUMN UserId INTEGER NULL");
}

static void TryExec(AppDbContext db, string sql)
{
    try { db.Database.ExecuteSqlRaw(sql); } catch { }
}

static void CleanupOrphanedActiveQuests(AppDbContext db)
{
    // Remove any templates with known bad titles and their active quests
    var badTitles = new[] { "love", "god" };
    var badTemplates = db.QuestTemplates
        .AsEnumerable()
        .Where(t => badTitles.Any(b => t.Title.Contains(b, StringComparison.OrdinalIgnoreCase)))
        .ToList();

    if (badTemplates.Any())
    {
        var badIds = badTemplates.Select(t => t.Id).ToList();
        var badActive = db.ActiveQuests.Where(a => badIds.Contains(a.QuestTemplateId)).ToList();
        db.ActiveQuests.RemoveRange(badActive);
        db.QuestTemplates.RemoveRange(badTemplates);
        db.SaveChanges();
    }

    // Remove active quests whose template no longer exists
    db.Database.ExecuteSqlRaw(@"
        DELETE FROM ActiveQuests
        WHERE QuestTemplateId NOT IN (SELECT Id FROM QuestTemplates)
    ");

    // Remove active quests where the template belongs to a different user
    db.Database.ExecuteSqlRaw(@"
        DELETE FROM ActiveQuests
        WHERE UserId IS NOT NULL
          AND EXISTS (
              SELECT 1 FROM QuestTemplates
              WHERE QuestTemplates.Id = ActiveQuests.QuestTemplateId
                AND QuestTemplates.UserId != ActiveQuests.UserId
          )
    ");
}

static void SeedDefaultData(AppDbContext db)
{
    if (!db.Profiles.Any())
    {
        db.Profiles.Add(new Profile
        {
            Id = 1,
            GlobalXp = 0,
            GlobalLevel = 1,
            QuestCapacity = 3
        });
    }

    var oldSeeds = new[] {
        "Read 10 pages of educational material",
        "Complete a 30-minute workout session",
        "Review monthly budget and savings goals"
    };
    var toRemove = db.QuestTemplates.Where(q => oldSeeds.Contains(q.Title)).ToList();
    if (toRemove.Any())
    {
        db.QuestTemplates.RemoveRange(toRemove);
    }

    db.SaveChanges();
}
