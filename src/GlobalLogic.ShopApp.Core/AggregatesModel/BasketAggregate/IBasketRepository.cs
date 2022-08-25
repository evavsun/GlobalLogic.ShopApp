namespace GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate
{
    public interface IBasketRepository
    {
        Task<Basket> GetOrCreateAsync(int userId);

        Task<Basket> GetAsync(int userId);

        Task UpdateAsync(int userId, Basket basket);

        Task DeleteAsync(int userId);
    }
}
