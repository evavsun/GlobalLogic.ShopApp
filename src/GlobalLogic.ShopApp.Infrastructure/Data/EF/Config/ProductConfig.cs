using Microsoft.EntityFrameworkCore;
using GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalLogic.ShopApp.Infrastructure.Data
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.ProductImages)
                .WithOne(pi => pi.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(p => p.Quantity, q => { q.Property(e => e.Quantity).HasColumnName("Quantity"); });
        }
    }
}
