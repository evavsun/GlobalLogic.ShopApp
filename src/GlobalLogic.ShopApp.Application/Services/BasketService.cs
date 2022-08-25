using GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate;
using GlobalLogic.ShopApp.Core.Dtos;
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

        public async Task<IEnumerable<BasketItemDto>> GetBusketItemsAsync(int userId)
        {
            var basket = await _basketStore.GetAsync(userId);
            var products = await _unitOfWork.Products.FindAsync(x => basket.Items.Select(i => i.ProductId).Contains(x.Id));
            return products.Select(x => new BasketItemDto(x));
        }

        public async Task AddProductAsync(int userId, int productId, int quantity)
        {
            var basket = await _basketStore.GetOrCreateAsync(userId);
            basket.AddProduct(productId, quantity);
            await _basketStore.UpdateAsync(userId, basket);
        }
    }
}
