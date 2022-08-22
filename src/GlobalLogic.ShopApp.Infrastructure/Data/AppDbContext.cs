using GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate;
using GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate;
using GlobalLogic.ShopApp.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace GlobalLogic.ShopApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }
    }
}
