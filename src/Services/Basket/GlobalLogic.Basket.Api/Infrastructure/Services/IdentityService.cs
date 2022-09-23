namespace GlobalLogic.Basket.Api.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string GetUserEmail()
        {
            return _context.HttpContext.User.Identity.Name;
        }
    }
}
