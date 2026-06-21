using Assignment_11._1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Assignment_11._1.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-EA8DDSO;initial catalog=PCAD20Books;integrated security=True;encrypt=False;trustservercertificate=True;MultipleActiveResultSets=True");
        }
    }
}
