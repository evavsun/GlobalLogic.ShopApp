namespace GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate
{
    public class OrderItem : Entity
    {
        public int ProductId { get; private set; }

        public int Quantity { get; private set; }

        public int OrderId { get; private set; }

        public Order? Order { get; private set; }

        public OrderItem(int productId, int quantity, int orderId)
        {
            ProductId = productId;
            Quantity = quantity;
            OrderId = orderId;
        }
    }
}
