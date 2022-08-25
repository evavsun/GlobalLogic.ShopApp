using GlobalLogic.ShopApp.Core.AggregatesModel.ApplicationUserAggregate;

namespace GlobalLogic.ShopApp.Core.Interfaces
{
    public interface ITokenProvider
    {
        string GetToken(ApplicationUser user);
    }
}
