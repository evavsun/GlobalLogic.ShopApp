using GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate;

namespace GlobalLogic.ShopApp.Core.Dtos
{
    public record class BasketItemDto
    {
        public int ProductId { get; init; }

        public string ProductName { get; init; }

        public decimal ProductPrice { get; init; }

        public string ProductDescription { get; init; }

        public string[] ProductImages { get; set; }

        public BasketItemDto(Product product)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            ProductPrice = product.Price;
            ProductDescription = product.Description;
            ProductImages = product.ProductImages.Select(x => x.Path).ToArray();
        }
    }
}
