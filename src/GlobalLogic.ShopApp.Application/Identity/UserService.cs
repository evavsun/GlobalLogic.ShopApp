using GlobalLogic.ShopApp.Core.AggregatesModel.IdentityUserAggregate;
using GlobalLogic.ShopApp.Core.Interfaces;

namespace GlobalLogic.ShopApp.Application.Identity
{
    internal class UserService : IUserService
    {
        public Task<string> LoginAsync(string login, string password)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
