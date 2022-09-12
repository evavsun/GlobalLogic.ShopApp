using StackExchange.Redis;
using System.Text.Json;
using GlobalLogic.Basket.Api.Interfaces;
using GlobalLogic.Basket.Api.Model;

namespace GlobalLogic.Basket.Api.Infrastructure
{
    public class RedisBasketRepository : IBasketRepository
    {
        private readonly ILogger<RedisBasketRepository> _logger;
        private readonly IDatabase _database;

        public RedisBasketRepository(ILoggerFactory loggerFactory, ConnectionMultiplexer redis)
        {
            _logger = loggerFactory.CreateLogger<RedisBasketRepository>();
            _database = redis.GetDatabase();
        }

        public Task<bool> DeleteBasketAsync(string id)
        {
            return _database.KeyDeleteAsync(id);
        }

        public async Task<CustomerBasket> GetBasketAsync(string customerId)
        {
            var data = await _database.StringGetAsync(customerId);

            if (data.IsNullOrEmpty)
            {
                return null;
            }

            return JsonSerializer.Deserialize<CustomerBasket>(data, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));

            if (!created)
            {
                _logger.LogInformation("Problem occur persisting the item.");
                return null;
            }

            _logger.LogInformation("Basket item persisted succesfully.");

            var x = await GetBasketAsync(basket.UserId);
            return await GetBasketAsync(basket.UserId);
        }
    }
}
