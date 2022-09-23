namespace GlobalLogic.Basket.Api.Contracts
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

        public CreateOrderRequest(BasketCheckoutRequest basketCheckoutRequest, CustomerBasket customerBasket)
        {
            Street = basketCheckoutRequest.Street;
            City = basketCheckoutRequest.City;
            State = basketCheckoutRequest.State;
            Country = basketCheckoutRequest.Country;
            ZipCode = basketCheckoutRequest.ZipCode;
            Description = basketCheckoutRequest.Description;
            PaymentMethodId = basketCheckoutRequest.PaymentMethodId;
            Products = customerBasket.Items
                .Select(x => new BasketItemDto() { ProductId = x.ProductId, Quantity = x.Quantity })
                .ToArray();
        }
    }
}
