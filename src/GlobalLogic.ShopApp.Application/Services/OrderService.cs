using GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate;
using GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate;
using GlobalLogic.ShopApp.Core.Interfaces;

namespace GlobalLogic.ShopApp.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketStore _basketStore;

        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IBasketStore basketStore, IUnitOfWork unitOfWork)
        {
            _basketStore = basketStore;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Order order)
        {
            var basket = await _basketStore.GetAsync(order.UserId);
            var products = await _unitOfWork.Products.FindAsync(basket.Items.Select(i => i.ProductId).ToArray());
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
            _basketStore.DeleteAsync(userId);
    }
}
