using Microsoft.EntityFrameworkCore;
using MVCForWharehouseManagement.Models;

namespace MVCForWharehouseManagement.Data
{
    public class WharehouseManagementContext : DbContext
    {
        public WharehouseManagementContext(DbContextOptions<WharehouseManagementContext> options) : base(options)
        {
        }

        public DbSet<Address> Addreses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedProducts> OrderedProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderedProducts>().ToTable("OrderedProducts");
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
