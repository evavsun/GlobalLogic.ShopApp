using GlobalLogic.Basket.Api.Infrastrucure.Exceptions;

namespace GlobalLogic.Basket.Api.Model
{
    public class BasketItem
    {
        public int ProductId { get; private set; }
        public string ProductName { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string ItemImage { get; private set; } = string.Empty;

        public BasketItem(int productId, string productName, decimal price, string itemImage, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            ItemImage = itemImage;
            AddQuantity(quantity);
        }

        public void AddQuantity(int quantity) =>
            Quantity += quantity <= 0 ? throw new QuantityEqualOrBelowZeroException() : quantity;
    }
}
