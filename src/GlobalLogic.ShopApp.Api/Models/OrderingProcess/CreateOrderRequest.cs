using GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate;

namespace GlobalLogic.ShopApp.Api.Models.OrderingProcess
{
    public class CreateOrderRequest
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PaymentMethodId { get; set; } = string.Empty;
        public BasketItemDto[] Products { get; set; }


        public Order MapToOrder(int userId)
        {
            var order = new Order(userId, new Address(Street, City, State, Country, ZipCode), Description, PaymentMethodId);

            foreach (var product in Products)
            {
                order.AddOrderItem(product.ProductId, product.Quantity);
            }

            return order;
        }

    }
}
