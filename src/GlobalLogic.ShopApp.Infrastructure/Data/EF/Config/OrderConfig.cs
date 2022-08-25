using Microsoft.EntityFrameworkCore;
using GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalLogic.ShopApp.Infrastructure.Data
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(o => o.Address);
        }
    }
}
