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
        private IApplicationUserRepository? _applicationUsers;
        private IProductRepository? _products;
        private IOrderRepository? _orders;

        public IApplicationUserRepository ApplicationUsers
        {
            get
            {
                if (_applicationUsers is null)
                    _applicationUsers = new ApplicationUserRepository(_appDbContext);
                return _applicationUsers;
            }
        }
        public IProductRepository Products
        {
            get
            {
                if (_products is null)
                    _products = new ProductRepository(_appDbContext);
                return _products;
            }
        }
        public IOrderRepository Orders
        {
            get
            {
                if (_orders is null)
                    _orders = new OrderRepository(_appDbContext);
                return _orders;
            }
        }

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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
