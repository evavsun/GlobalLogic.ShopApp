namespace GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate
{
    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductId { get; private set; }

        public Product? Product { get; private set; }

        public string Path { get; private set; }

        public ProductImage(string path, int productId)
        {
            Path = path;
            ProductId = productId;
        }
    }
}
