using Microsoft.EntityFrameworkCore;

namespace PartialFoods.Services.OrderManagementServer.Entities
{
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=orders;Username=postgres;Password=wopr");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasKey(o => o.OrderID);

            builder.Entity<LineItem>()
                .HasKey(li => new { li.OrderID, li.SKU });
        }
    }
}