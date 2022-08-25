using GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate;

namespace GlobalLogic.ShopApp.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Order order)
        {
            await _dbContext.AddAsync(order);
        }
    }
}
