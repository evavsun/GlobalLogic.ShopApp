namespace GlobalLogic.Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly OrderingProcessService _orderingProcessService;
        private readonly IIdentityService _identityService;

        public BasketController(IBasketRepository basketRepository,
            OrderingProcessService orderingProcessService,
            IIdentityService identityService)
        {
            _basketRepository = basketRepository;
            _orderingProcessService = orderingProcessService;
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket()
        {
            var userEmail = _identityService.GetUserEmail();
            var basket = await _basketRepository.GetBasketAsync(userEmail);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] BasketItem basketItem)
        {
            var userEmail = _identityService.GetUserEmail();
            var basket = await _basketRepository.GetBasketAsync(userEmail) ?? new CustomerBasket(userEmail);
            basket.AddItem(basketItem);
            return Ok(await _basketRepository.UpdateBasketAsync(basket));
        }

        [HttpPost("checkout")]
        public async Task<ActionResult> Checkout([FromBody] BasketCheckoutRequest request)
        {
            var userEmail = _identityService.GetUserEmail();
            var basket = await _basketRepository.GetBasketAsync(userEmail);
            if (basket is null)
                return NotFound();

            //TODO: add polly here
            var createOrderRequest = new CreateOrderRequest(request, basket);
            await _orderingProcessService.CreateOrderAsync(createOrderRequest);
            await _basketRepository.DeleteBasketAsync(userEmail);
            return Accepted();
        }
    }
}
