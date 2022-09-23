using GlobalLogic.ShopApp.Core.Interfaces;
using GlobalLogic.ShopApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalLogic.ShopApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AccountController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] ApplicationUserRequest applicationUserRequest)
        {
            var token = await _authorizationService.LoginAsync(applicationUserRequest.Login, applicationUserRequest.Password);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] ApplicationUserRequest applicationUserRequest)
        {
            await _authorizationService.RegisterAsync(applicationUserRequest.Login, applicationUserRequest.Password);
            return Ok();
        }
    }
}
