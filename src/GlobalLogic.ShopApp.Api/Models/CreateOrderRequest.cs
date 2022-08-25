using GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate;

namespace GlobalLogic.ShopApp.Api.Models
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

        public Order MapToOrder(int userId) =>
            new(userId, new Address(Street, City, State, Country, ZipCode), Description, PaymentMethodId);
    }
}
