using ComproPikoulasTest.Core;
using Microsoft.EntityFrameworkCore;

namespace ComproPikoulasTest.Data
{
    public interface IComproPikoulasTestDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
    }
}