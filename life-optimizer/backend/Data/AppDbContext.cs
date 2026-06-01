using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Backend.Models;

namespace LifeOptimizer.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Stat> Stats => Set<Stat>();
        public DbSet<QuestTemplate> QuestTemplates => Set<QuestTemplate>();
        public DbSet<ActiveQuest> ActiveQuests => Set<ActiveQuest>();
        public DbSet<Profile> Profiles => Set<Profile>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Friendship> Friendships => Set<Friendship>();
        public DbSet<SharedQuest> SharedQuests => Set<SharedQuest>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Profile → User (nullable: anonymous users have UserId == null)
            modelBuilder.Entity<Profile>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            // ActiveQuest → QuestTemplate
            modelBuilder.Entity<ActiveQuest>()
                .HasOne(a => a.QuestTemplate)
                .WithMany()
                .HasForeignKey(a => a.QuestTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            // ActiveQuest → User (nullable)
            modelBuilder.Entity<ActiveQuest>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // QuestTemplate → User (nullable)
            modelBuilder.Entity<QuestTemplate>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(q => q.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            // Stat → User (nullable)
            modelBuilder.Entity<Stat>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            // Friendship → User (requester)
            modelBuilder.Entity<Friendship>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Friendship → User (receiver) — restrict to avoid multiple cascade paths
            modelBuilder.Entity<Friendship>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            // SharedQuest → User (sender)
            modelBuilder.Entity<SharedQuest>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.SenderId)
                .OnDelete(DeleteBehavior.Cascade);

            // SharedQuest → User (receiver)
            modelBuilder.Entity<SharedQuest>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
