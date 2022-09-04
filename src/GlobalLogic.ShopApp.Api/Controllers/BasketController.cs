using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GlobalLogic.ShopApp.Core.Interfaces;
using GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate;

namespace GlobalLogic.ShopApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        private readonly IUnitOfWork _unitOfWork;

        public BasketController(IBasketService basketService, IUnitOfWork unitOfWork)
        {
            _basketService = basketService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasket()
        {
            var user = await _unitOfWork.ApplicationUsers.GetAsync(HttpContext.User.Identity.Name);
            var basket = await _basketService.GetBusketAsync(user.Id);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] BasketItem basketItem)
        {
            var user = await _unitOfWork.ApplicationUsers.GetAsync(HttpContext.User.Identity.Name);
            await _basketService.AddProductAsync(user.Id, basketItem);
            return Ok();
        }
    }
}
