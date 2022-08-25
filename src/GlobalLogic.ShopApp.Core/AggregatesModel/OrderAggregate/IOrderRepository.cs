namespace GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);
    }
}
