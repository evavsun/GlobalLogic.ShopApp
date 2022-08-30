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

        public Product(string name, string description, ProductPrice price, ProductQuantity quantity)
        {
            Name = name;
            Description = description;
            Price = price;
            CreateDate = DateTime.UtcNow;
            Quantity = quantity;
            _productImages = new List<ProductImage>();
        }

        public void SetName(string name)
        {
            Name = name;
        }


        public void SetDescription(string description)
        {
            Description = description;
        }


        public void AddProductImage(string path) =>
            _productImages.Add(new ProductImage(path, Id));

        public void RemoveProductImage(ProductImage productImage) =>
            _productImages.Remove(productImage);
    }
}
