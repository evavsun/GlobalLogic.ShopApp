using GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
namespace GlobalLogic.ShopApp.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Product[]> GetAllAsync(int page, int count) =>
            _dbContext.Products.Include(x => x.ProductImages)
            .Skip(page)
            .Take(count)
            .ToArrayAsync();

        public Task<Product?> GetByIdAsync(int id) =>
            _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        public Task<Product[]> FindAsync(params int[] ids) =>
             _dbContext.Products.Where(x => ids.Contains(x.Id))
            .Include(x => x.ProductImages).ToArrayAsync();

        public async Task AddAsync(Product product) =>
            await _dbContext.AddAsync(product);

        public void Remove(Product product) =>
            _dbContext.Remove(product);
    }
}
