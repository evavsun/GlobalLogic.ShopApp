namespace GlobalLogic.Basket.Api.Contracts
{
    public class BasketCheckoutRequest
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PaymentMethodId { get; set; } = string.Empty;
    }
}
