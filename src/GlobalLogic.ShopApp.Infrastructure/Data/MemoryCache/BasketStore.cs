using Microsoft.Extensions.Caching.Memory;
using GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate;

namespace GlobalLogic.ShopApp.Infrastructure.Data.MemoryCache
{
    // TODO: migrate to Redis
    public class BasketStore : IBasketStore
    {
        private readonly IMemoryCache _memoryCache;

        public BasketStore(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<Basket> GetOrCreateAsync(int userId)
        {
            var result = _memoryCache.GetOrCreate(userId, x =>
            {
                var basket = new Basket(userId);
                x.SetValue(basket);
                return basket;
            });

            return Task.FromResult(result);
        }

        public Task<Basket> GetAsync(int userId) =>
            Task.FromResult(_memoryCache.Get<Basket>(userId));

        public Task UpdateAsync(int userId, Basket basket)
        {
            _memoryCache.Set(userId, basket);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int userId)
        {
            _memoryCache.Remove(userId);
            return Task.CompletedTask;
        }
    }
}
