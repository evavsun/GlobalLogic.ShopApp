using GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate;

namespace GlobalLogic.ShopApp.Api.Models.Products
{
    public class ProductUpdateRequest
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Qunatity { get; set; }

        public string Description { get; set; } = string.Empty;

        public Product MapToProduct(Product product)
        {
            product.SetName(Name);
            product.Price.SetPrice(Price);
            product.Quantity.SetQuantity(Qunatity);
            product.SetDescription(Description);
            return product;
        }
    }
}
