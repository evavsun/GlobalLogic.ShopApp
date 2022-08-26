using GlobalLogic.ShopApp.Core.Exceptions;

namespace GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate
{
    public class ProductQuantity
    {
        public int Quantity { get; private set; }

        public ProductQuantity(int quantity)
        {
            SetQuantity(quantity);
        }

        public void SetQuantity(int quantity) =>
            Quantity = quantity > 0 ? quantity : throw new QuantityEqualOrBelowZeroException();

        public void DecreaseQuantity(int quantity)
        {
            var decreasedQuantity =- quantity > Quantity
                ? throw new ProductQuntityIsNotAvailableException($"This quantity is not available for product. Available quantity is {Quantity}")
                : quantity;
            SetQuantity(decreasedQuantity);
        }
    }
}
