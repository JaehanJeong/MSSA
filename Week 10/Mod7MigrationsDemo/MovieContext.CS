using System;
using System.Collections.Generic;
using System.Text;

namespace Mod7MigrationsDemo
{
    public class MovieContext : DbContext;
    {

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EA8DDSO;Database=PCAD20Movies;Trusted_Connection=True;Integrated Security=True;trustservercertificate=True");
        }
        
 
    }
}
