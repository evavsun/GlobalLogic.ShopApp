using GlobalLogic.ShopApp.Core.Exceptions;

namespace GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate
{
    public record class ProductQuantity
    {
        public int Quantity { get; init; }

        public ProductQuantity(int quantity)
        {
            Quantity = quantity > 0 ? quantity : throw new QuantityEqualOrBelowZeroException();
        }
    }
}
