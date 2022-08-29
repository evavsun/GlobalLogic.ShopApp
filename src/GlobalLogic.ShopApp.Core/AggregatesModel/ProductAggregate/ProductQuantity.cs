using GlobalLogic.ShopApp.Core.Exceptions;

namespace GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate
{
    public record class ProductQuantity
    {
        public int Quantity { get; private set; }

        public ProductQuantity(int quantity)
        {
            SetQuantity(quantity);
        }

        public void SetQuantity(int quantity)
        {
            ValidateQunatity(quantity);
            Quantity = quantity;
        }

        public void DecreaseQuantity(int quantity)
        {
            ValidateQunatity(quantity);
            Quantity =- quantity > Quantity
                ? throw new ProductQuntityIsNotAvailableException($"This quantity is not available for product. Available quantity is {Quantity}")
                : quantity;
        }

        private void ValidateQunatity(int quantity)
        {
            if (quantity > 0)
                return;
            throw new QuantityEqualOrBelowZeroException();
        }
    }
}
