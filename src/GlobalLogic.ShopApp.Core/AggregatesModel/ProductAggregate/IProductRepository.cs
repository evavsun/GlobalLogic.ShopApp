namespace GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate
{
    public interface IProductRepository
    {
        Task<Product[]> GetAllAsync(int page, int count);

        Task<Product[]> FindAsync(params int[] ids);

        Task<Product?> GetByIdAsync(int id);

        Task AddAsync(Product product);

        void Remove(Product product);
    }
}
