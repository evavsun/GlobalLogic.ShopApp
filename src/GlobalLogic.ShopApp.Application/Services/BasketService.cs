using GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate;
using GlobalLogic.ShopApp.Core.Interfaces;

namespace GlobalLogic.ShopApp.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketStore _basketStore;
        private readonly IUnitOfWork _unitOfWork;

        public BasketService(IBasketStore basketStore, IUnitOfWork unitOfWork)
        {
            _basketStore = basketStore;
            _unitOfWork = unitOfWork;
        }

        public Task<Basket> GetBusketAsync(int userId)
        {
            return _basketStore.GetAsync(userId);
        }

        public async Task AddProductAsync(int userId, BasketItem basketItem)
        {
            var basket = await _basketStore.GetOrCreateAsync(userId);
            basket.AddItem(basketItem);
            await _basketStore.UpdateAsync(userId, basket);
        }
    }
}
