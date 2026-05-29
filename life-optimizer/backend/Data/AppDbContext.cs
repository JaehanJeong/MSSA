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
    }
}
