using System.Linq.Expressions;

namespace GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate
{
    public interface IProductRepository
    {
        Task<Product[]> FindAsync(Expression<Func<Product, bool>> predicate);
    }
}
