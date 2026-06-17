using Microsoft.EntityFrameworkCore;

namespace WebApidemo
{
    public class MovieContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public MovieContext(DbContextOptions<MovieContext>options):base(options)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Title = "Parasite", ReleaseYear = 2019, Genre = "Thriller/Comedy"}

                
                );
        }
    }
}
