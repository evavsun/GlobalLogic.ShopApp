namespace GlobalLogic.ShopApp.Core.Interfaces
{
    public interface IAuthorizationService
    {
        Task RegisterAsync(string login, string password);

        Task<string> LoginAsync(string login, string password);
    }
}
