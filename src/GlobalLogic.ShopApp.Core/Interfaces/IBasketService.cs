using GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate;

namespace GlobalLogic.ShopApp.Core.Interfaces
{
    public interface IBasketService
    {
        Task<Basket> GetBusketAsync(int userId);
        Task AddProductAsync(int userId, BasketItem basketItem);
    }
}
