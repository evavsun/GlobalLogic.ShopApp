namespace GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate
{
    public class Basket
    {
        public int UserId { get; private set; }

        private readonly List<BasketItem> _items;

        public IReadOnlyCollection<BasketItem> Items => _items;

        public Basket(int userId)
        {
            UserId = userId;
            _items = new List<BasketItem>();
        }

        public void AddItem(BasketItem basketItem)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == basketItem.ProductId);
            if (existingItem is null)
            {
                _items.Add(basketItem); ;
                return;
            }
            existingItem.AddQuantity(basketItem.Quantity);
        }

        public void RemoveItem(int productId)
        {
            var item = _items.SingleOrDefault(i => i.ProductId == productId);
            _items.Remove(item);
        }
    }
}
