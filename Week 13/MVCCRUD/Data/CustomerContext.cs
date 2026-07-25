using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models;

namespace MVCCRUD.Data
{
    public class CustomerContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomerContext (DbContextOptions<CustomerContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Frank V", Email = "1234@gmail.com", PostalAddress = "123 main st" }
                );
        }
    }
}
