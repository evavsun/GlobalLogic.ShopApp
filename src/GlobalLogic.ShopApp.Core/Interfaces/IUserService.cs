using GlobalLogic.ShopApp.Core.AggregatesModel.IdentityUserAggregate;

namespace GlobalLogic.ShopApp.Core.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(ApplicationUser user);

        Task<string> LoginAsync(string login, string password);
    }
}
