using GlobalLogic.ShopApp.Core.AggregatesModel.ApplicationUserAggregate;
using GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate;
using GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate;

namespace GlobalLogic.ShopApp.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository ApplicationUsers { get; }

        IProductRepository Products { get; }

        IOrderRepository Orders { get; }

        Task<int> SaveAsync();
    }
}
