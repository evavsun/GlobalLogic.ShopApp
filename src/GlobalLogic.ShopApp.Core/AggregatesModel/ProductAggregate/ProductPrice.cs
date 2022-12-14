using GlobalLogic.ShopApp.Core.Exceptions;

namespace GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate
{
    public record ProductPrice
    {
        public decimal Price { get; init; }

        public ProductPrice(decimal price)
        {
            Price = price < 0 ? throw new ProductPriceException() : price;
        }
    }
}
