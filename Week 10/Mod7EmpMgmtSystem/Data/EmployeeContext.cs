using Microsoft.EntityFrameworkCore;
using Mod7EmpMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mod7EmpMgmtSystem.Data
{
    //represents the db
    public class EmployeeContext:DbContext
    {
        public DbSet<Department>Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-EA8DDSO;initial catalog=PCAD20Employees;integrated security=True;encrypt=False;trustservercertificate=True;MultipleActiveResultSets=True");

        }
        //data seeding : adding records when db is created
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DeptId);

            modelBuilder.Entity<Department>().HasData(
                new Department { DeptId = 1, DeptName = "HR", Location = "NC" },
                new Department { DeptId = 2, DeptName = "Marketing", Location = "NY" },
                new Department { DeptId = 3, DeptName = "Sales", Location = "Chicago" }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmpId = 101, DeptId = 1, EmpName = "Amy Faber", Salary = 80000 }
                );
        }
    }


}
