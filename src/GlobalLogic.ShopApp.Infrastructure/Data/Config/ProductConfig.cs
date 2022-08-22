using Microsoft.EntityFrameworkCore;
using GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalLogic.ShopApp.Infrastructure.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.ProductImages)
                .WithOne()
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
