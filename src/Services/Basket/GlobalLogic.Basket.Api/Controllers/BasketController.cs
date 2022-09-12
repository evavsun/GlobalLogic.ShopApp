using GlobalLogic.Basket.Api.Interfaces;
using GlobalLogic.Basket.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalLogic.Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket()
        {
            var customerId = "get login from HTTP Context";
            var basket = await _basketRepository.GetBasketAsync(customerId);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] BasketItem basketItem)
        {
            var customerId = "get login from HTTP Context";
            var basket = await _basketRepository.GetBasketAsync(customerId) ?? new CustomerBasket(customerId);
            basket.AddItem(basketItem);
            return Ok(await _basketRepository.UpdateBasketAsync(basket));
        }
    }
}
