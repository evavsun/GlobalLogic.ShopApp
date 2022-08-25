using GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate;
using GlobalLogic.ShopApp.Core.Dtos;
using GlobalLogic.ShopApp.Core.Interfaces;

namespace GlobalLogic.ShopApp.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BasketItemDto>> GetBusketItemsAsync(int userId)
        {
            var basket = await _unitOfWork.Basket.GetAsync(userId);
            var products = await _unitOfWork.Products.FindAsync(x => basket.Items.Select(i => i.ProductId).Contains(x.Id));
            return products.Select(x => new BasketItemDto(x));
        }

        public async Task AddProductAsync(int userId, int productId, int quantity)
        {
            var basket = await _unitOfWork.Basket.GetOrCreateAsync(userId);
            basket.AddProduct(productId, quantity);
            await _unitOfWork.Basket.UpdateAsync(userId, basket);
        }
    }
}
