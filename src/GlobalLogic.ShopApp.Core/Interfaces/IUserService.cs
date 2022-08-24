using GlobalLogic.ShopApp.Core.AggregatesModel.ApplicationUserAggregate;

namespace GlobalLogic.ShopApp.Core.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(string login, string password);

        Task<string> LoginAsync(string login, string password);
    }
}
