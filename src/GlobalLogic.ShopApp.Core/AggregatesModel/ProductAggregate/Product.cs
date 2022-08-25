﻿using GlobalLogic.ShopApp.Core.Exceptions;

namespace GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public DateTime CreateDate { get; private set; }

        public DateTime? UpdateDate { get; private set; }

        public string Description { get; private set; }

        private readonly List<ProductImage> _productImages;

        public IReadOnlyCollection<ProductImage> ProductImages => _productImages;

        public Product(string name, string description, decimal price, int quantity)
        {
            Name = name;
            Description = description;
            Price = ValidatePrice(price) ? price : throw new ProductPriceException();
            CreateDate = DateTime.UtcNow;
            Quantity = ValidateQunatity(quantity) ? quantity : throw new QuantityEqualOrBelowZeroException();
            _productImages = new List<ProductImage>();
        }

        public void AddProductImage(string path) =>
            _productImages.Add(new ProductImage(path, Id));

        public void DecreaseQuantity(int quantity)
        {
            if (!ValidateQunatity(quantity))
                throw new QuantityEqualOrBelowZeroException();
            Quantity =- quantity > Quantity
                ? throw new ProductQuntityIsNotAvailableException($"This quantity is not available for product - {Name}. Available quantity is {Quantity}")
                : quantity;
        }

        private bool ValidateQunatity(int quantity) =>
            quantity > 0;

        private bool ValidatePrice(decimal price) =>
            price >= 0;
    }
}
