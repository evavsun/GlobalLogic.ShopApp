namespace GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate
{
    public class Basket : Entity, IAggregateRoot
    {
        public string UserId { get; private set; }

        private readonly List<BasketItem> _items;

        public IReadOnlyCollection<BasketItem> Items => _items;

        public Basket(string userId)
        {
            UserId = userId;
            _items = new List<BasketItem>();
        }

        public void AddItem(int productId, int quantity = 1)
        {
            if (!Items.Any(i => i.ProductId == productId))
            {
                _items.Add(new BasketItem(productId, quantity));
                return;
            }
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            existingItem.AddQuantity(quantity);
        }
    }
}
