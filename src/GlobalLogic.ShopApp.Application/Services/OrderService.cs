using GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate;
using GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate;
using GlobalLogic.ShopApp.Core.Interfaces;

namespace GlobalLogic.ShopApp.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepository;

        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Order order)
        {
            var basket = await _basketRepository.GetAsync(order.UserId);
            var products = await _unitOfWork.Products.FindAsync(x => basket.Items.Select(i => i.ProductId).Contains(x.Id));
            foreach (var item in basket.Items)
            {
                var product = products.First(x => x.Id == item.ProductId);
                product.DecreaseQuantity(item.Quantity);
                order.AddOrderItem(item.ProductId, item.Quantity);
            }
            await _unitOfWork.Orders.CreateAsync(order);
            await _unitOfWork.SaveAsync();
            await CleanUpBasket(order.UserId);
        }

        private Task CleanUpBasket(int userId) =>
            _basketRepository.DeleteAsync(userId);
    }
}
