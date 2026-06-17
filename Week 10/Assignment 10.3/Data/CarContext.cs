using Assignment_10._3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_10._3.Data
{
    public class CarContext:DbContext
    {
        public DbSet<Car>Cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-EA8DDSO;initial catalog=PCAD20Cars;integrated security=True;encrypt=False;trustservercertificate=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car { Make = "Toyota", Model = "Prius", Price = 20000, VIN = 1234, Year = 2020 },
                new Car { Make = "Honda", Model = "Civic", Price = 25000, VIN = 2345, Year = 2023 },
                new Car { Make = "Tesla", Model = "Cyber Truck", Price = 50000, VIN = 3456, Year = 2024 },
                new Car { Make = "Hyundai", Model = "Ioniq", Price = 40000, VIN = 4567, Year = 2026 },
                new Car { Make = "Ford", Model = "F150", Price = 40000, VIN = 5678, Year = 2026 }
                );


        }
    }
}
