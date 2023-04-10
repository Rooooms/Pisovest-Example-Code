using CustomerPOS.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerPOS.Data
{
    
        public class DataContext : DbContext
        {
            public DataContext() { }
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {

            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlServer("Server = LAPTOP-PCASNR8E;Database=CustomerDb;Trusted_Connection=True;TrustServerCertificate=True");
            }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Purchase> Purchases { get; set;}


        }
    }

