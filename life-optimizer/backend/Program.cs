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
    SeedDefaultData(db);
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

    if (!db.Stats.Any())
    {
        db.Stats.AddRange(
            new Stat { Subject = "Health", Level = 50, Weight = 1.0 },
            new Stat { Subject = "Intelligence", Level = 50, Weight = 1.0 },
            new Stat { Subject = "Relationships", Level = 50, Weight = 1.0 },
            new Stat { Subject = "Wealth", Level = 50, Weight = 1.0 },
            new Stat { Subject = "Spiritual", Level = 50, Weight = 1.0 },
            new Stat { Subject = "Purpose", Level = 50, Weight = 1.0 }
        );
    }

    if (!db.QuestTemplates.Any())
    {
        db.QuestTemplates.AddRange(
            new QuestTemplate { Title = "Read 10 pages of educational material", Stat = "Intelligence", Rarity = "Common", XpReward = 10 },
            new QuestTemplate { Title = "Complete a 30-minute workout session", Stat = "Health", Rarity = "Rare", XpReward = 25 },
            new QuestTemplate { Title = "Review monthly budget and savings goals", Stat = "Wealth", Rarity = "Epic", XpReward = 75 }
        );
    }

    db.SaveChanges();
}
