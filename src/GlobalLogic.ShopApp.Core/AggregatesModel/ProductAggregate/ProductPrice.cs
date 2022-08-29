using GlobalLogic.ShopApp.Core.Exceptions;

namespace GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate
{
    public class ProductPrice
    {
        public decimal Price { get; private set; }

        public ProductPrice(decimal price)
        {
            SetPrice(price);
        }

        public void SetPrice(decimal price)
        {
            Price = price < 0 ? throw new ProductPriceException() : price;
        }
    }
}
