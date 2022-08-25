using GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate;

namespace GlobalLogic.ShopApp.Core.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(Order order);
    }
}
