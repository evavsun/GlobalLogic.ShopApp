namespace GlobalLogic.Basket.Api.Http
{
    public class OrderingProcessService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderingProcessService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri(configuration.GetValue<string>("OrderingServiceHost"));
            _httpClient.DefaultRequestHeaders.Add("Authorization",
                _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString());
        }

        public async Task CreateOrderAsync(CreateOrderRequest request)
        {
            var requestJson = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                Application.Json);

            using var httpResponseMessage = await _httpClient.PostAsync("Order", requestJson);

            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
