namespace GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate
{
    public class BasketItem : Entity
    {
        public int ProductId { get; private set; }

        public int Quantity { get; private set; }

        public BasketItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public void AddQuantity(int quantity) =>
            Quantity += quantity <= 0 ? throw new ArgumentException() : quantity;
    }
}
