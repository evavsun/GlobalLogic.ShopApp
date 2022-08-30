using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GlobalLogic.ShopApp.Core.Interfaces;
using GlobalLogic.ShopApp.Api.Models;

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
        public async Task<ActionResult<IEnumerable<BasketItemResponse>>> GetBasketItems()
        {
            var user = await _unitOfWork.ApplicationUsers.GetAsync(HttpContext.User.Identity!.Name!);
            var items = await _basketService.GetBusketItemsAsync(user!.Id);
            var result = items.Select(x => new BasketItemResponse(x));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] AddItemIntoBasketRequest addItemIntoBasketRequest)
        {
            var user = await _unitOfWork.ApplicationUsers.GetAsync(HttpContext.User.Identity!.Name!);
            await _basketService.AddProductAsync(user!.Id, addItemIntoBasketRequest.ProductId, addItemIntoBasketRequest.Quantity);
            return Ok();
        }
    }
}
