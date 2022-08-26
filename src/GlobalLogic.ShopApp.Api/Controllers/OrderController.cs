using GlobalLogic.ShopApp.Api.Models;
using GlobalLogic.ShopApp.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalLogic.ShopApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IOrderService orderService, IUnitOfWork unitOfWork)
        {
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderRequest createOrderRequest)
        {
            var user = await _unitOfWork.ApplicationUsers.GetAsync(HttpContext!.User!.Identity!.Name!);
            await _orderService.CreateAsync(createOrderRequest.MapToOrder(user!.Id));
            return Ok();
        }
    }
}
