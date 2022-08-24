namespace GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public int UserId { get; private set; }

        public DateTime OrderDate { get; private set; }

        public Address Address { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        public string Description { get; private set; }

        public string PaymentMethodId { get; private set; }

        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order(int userId, Address address, string description, string paymentMethodId)
        {
            UserId = userId;
            OrderDate = DateTime.UtcNow;
            _orderItems = new List<OrderItem>();
            Description = description;
            Address = address;
            PaymentMethodId = paymentMethodId;
            OrderStatus = OrderStatus.PendingPayment;
        }

        public void AddOrderItem(int productId, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            _orderItems.Add(new OrderItem(productId, quantity, Id));
        }

        public void SetStatus(OrderStatus status) =>
            OrderStatus = status;
    }
}
