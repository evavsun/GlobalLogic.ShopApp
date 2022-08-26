using Microsoft.AspNetCore.Mvc;
using GlobalLogic.ShopApp.Core.Interfaces;
using GlobalLogic.ShopApp.Api.Models;

namespace GlobalLogic.ShopApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthorizationService _userService;

        public AccountController(IAuthorizationService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] ApplicationUserRequest applicationUserRequest)
        {
            var token = await _userService.LoginAsync(applicationUserRequest.Login, applicationUserRequest.Password);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] ApplicationUserRequest applicationUserRequest)
        {
            await _userService.RegisterAsync(applicationUserRequest.Login, applicationUserRequest.Password);
            return Ok();
        }
    }
}
