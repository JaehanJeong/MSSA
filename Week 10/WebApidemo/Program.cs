
using Microsoft.EntityFrameworkCore;

namespace WebApidemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("MovieContext") ?? throw new InvalidOperationException("Connection string 'MovieContext' not found.");

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<MovieContext>(options => options.UseSqlite("Data Source=movies.db"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            using(var scope = app.Services.CreateScope())
            {
                var db=scope.ServiceProvider.GetRequiredService<MovieContext>();
                //db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
