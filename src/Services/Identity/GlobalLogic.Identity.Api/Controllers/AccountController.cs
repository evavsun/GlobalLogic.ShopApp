namespace GlobalLogic.Identity.Api.Controllers
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
        public async Task<ActionResult<JwtResult>> Login([FromBody] LoginRequestModel loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _authorizationService.LoginAsync(loginRequest);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequestModel registerRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await _authorizationService.RegisterAsync(registerRequest);
            return Ok();
        }
    }
}
