#nullable disable
using CompanySample.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanySample.Data
{
    public class CompanySampleContext : DbContext
    {
        public CompanySampleContext (DbContextOptions<CompanySampleContext> options)
            : base(options)
        {
        }

        public CompanySampleContext(): base()
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}


