using ComproPikoulasTest.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ComproPikoulasTest.Data
{
    public class ComproPikoulasTestDbContext : DbContext, IComproPikoulasTestDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }


        public ComproPikoulasTestDbContext(DbContextOptions<ComproPikoulasTestDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
               .HasMany(a => a.Orders)
               .WithOne(b => b.Customer)
               .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }


}

