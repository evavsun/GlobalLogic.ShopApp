using GlobalLogic.ShopApp.Core.Dtos;

namespace GlobalLogic.ShopApp.Core.Interfaces
{
    public interface IBasketService
    {
        Task<IEnumerable<BasketItemDto>> GetBusketItemsAsync(int userId);
        Task AddProductAsync(int userId, int productId, int quantity);
    }
}
