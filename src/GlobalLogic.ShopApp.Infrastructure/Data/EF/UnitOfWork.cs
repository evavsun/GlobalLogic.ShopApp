using GlobalLogic.ShopApp.Core.AggregatesModel.ApplicationUserAggregate;
using GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate;
using GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate;
using GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate;
using GlobalLogic.ShopApp.Core.Interfaces;
using GlobalLogic.ShopApp.Infrastructure.Data.MemoryCache;
using Microsoft.Extensions.Caching.Memory;

namespace GlobalLogic.ShopApp.Infrastructure.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMemoryCache _memoryCache;
        private IApplicationUserRepository? _applicationUsers;
        private IProductRepository? _products;
        private IOrderRepository? _orders;
        private IBasketRepository? _basket;

        public IApplicationUserRepository ApplicationUsers => _applicationUsers ?? new ApplicationUserRepository(_appDbContext);
        public IProductRepository Products => _products ?? new ProductRepository(_appDbContext);
        public IOrderRepository Orders => _orders ?? new OrderRepository(_appDbContext);
        public IBasketRepository Basket => _basket ?? new BasketRepository(_memoryCache);

        public UnitOfWork(AppDbContext appDbContext, IMemoryCache memoryCache)
        {
            _appDbContext = appDbContext;
            _memoryCache = memoryCache;
        }

        public Task<int> SaveAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _appDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
