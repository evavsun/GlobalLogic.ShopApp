namespace GlobalLogic.Basket.Api.Model
{
    public class CustomerBasket
    {
        public string UserEmail { get; private set; }

        public List<BasketItem> Items { get; set; } = new();


        public CustomerBasket(string userEmail)
        {
            UserEmail = userEmail;
        }

        public void AddItem(BasketItem basketItem)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == basketItem.ProductId);
            if (existingItem is null)
            {
                Items.Add(basketItem);
                return;
            }
            existingItem.AddQuantity(basketItem.Quantity);
        }

        public void RemoveItem(int productId)
        {
            var item = Items.SingleOrDefault(i => i.ProductId == productId);
            Items.Remove(item);
        }
    }
}
