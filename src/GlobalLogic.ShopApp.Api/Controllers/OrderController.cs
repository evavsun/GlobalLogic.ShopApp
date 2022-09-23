using GlobalLogic.ShopApp.Api.Models.OrderingProcess;
using GlobalLogic.ShopApp.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var userEmail = HttpContext.User.Identity.Name;
            return Ok("Communication works fine");

            //var user = await _unitOfWork.ApplicationUsers.GetAsync(HttpContext.User.Identity.Name);
            //await _orderService.CreateAsync(createOrderRequest.MapToOrder(user.Id));
            //return Ok();
        }
    }
}
