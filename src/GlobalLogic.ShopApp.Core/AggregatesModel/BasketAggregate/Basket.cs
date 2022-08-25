namespace GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate
{
    public class Basket : Entity, IAggregateRoot
    {
        public int UserId { get; private set; }

        private readonly List<BasketItem> _items;

        public IReadOnlyCollection<BasketItem> Items => _items;

        public Basket(int userId)
        {
            UserId = userId;
            _items = new List<BasketItem>();
        }

        public void AddProduct(int productId, int quantity = 1)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem is null)
            {
                _items.Add(new BasketItem(productId, quantity));
                return;
            }
            existingItem.AddQuantity(quantity);
        }
    }
}
