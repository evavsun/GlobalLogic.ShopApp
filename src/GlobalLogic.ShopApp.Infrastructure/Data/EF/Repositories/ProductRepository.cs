using GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GlobalLogic.ShopApp.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Product[]> FindAsync(Expression<Func<Product, bool>> predicate)
        {
            return _dbContext.Products.Where(predicate).Include(x => x.ProductImages).ToArrayAsync();
        }
    }
}
