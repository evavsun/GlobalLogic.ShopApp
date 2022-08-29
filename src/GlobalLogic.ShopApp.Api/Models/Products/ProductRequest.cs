using GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate;

namespace GlobalLogic.ShopApp.Api.Models.Products
{
    public class ProductRequest
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Qunatity { get; set; }

        public string Description { get; set; } = string.Empty;

        public string[] ProductImages { get; set; }

        public Product MapToProduct() =>
            new(Name, Description, Price, Qunatity);
    }
}
