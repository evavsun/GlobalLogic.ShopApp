namespace GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate
{
    public class Product : IAggregateRoot
    {
        public int Id { get; set; }

        public string Name { get; private set; }

        public ProductPrice Price { get; private set; }

        public ProductQuantity Quantity { get; private set; }

        public DateTime CreateDate { get; private set; }

        public DateTime? UpdateDate { get; private set; }

        public string Description { get; private set; }

        private readonly List<ProductImage> _productImages;

        public IReadOnlyCollection<ProductImage> ProductImages => _productImages;

        protected Product() { }

        public Product(string name, string description, decimal price, int quantity)
        {
            Name = name;
            Description = description;
            Price = new ProductPrice(price);
            CreateDate = DateTime.UtcNow;
            Quantity = new ProductQuantity(quantity);
            _productImages = new List<ProductImage>();
        }

        public void AddProductImage(string path) =>
            _productImages.Add(new ProductImage(path, Id));
    }
}
