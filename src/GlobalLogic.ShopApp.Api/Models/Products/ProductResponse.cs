using GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate;

namespace GlobalLogic.ShopApp.Api.Models.Products
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Qunatity { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime CreateDate { get; private set; }

        public DateTime? UpdateDate { get; private set; }

        public string[] ProductImages { get; set; }

        public ProductResponse(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price.Price;
            Qunatity = product.Quantity.Quantity;
            Description = product.Description;
            CreateDate = product.CreateDate;
            UpdateDate = product.UpdateDate;
            ProductImages = product.ProductImages.Select(x => x.Path).ToArray();
        }
    }
}
