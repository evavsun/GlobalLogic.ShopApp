using GlobalLogic.ShopApp.Core.Dtos;

namespace GlobalLogic.ShopApp.Api.Models
{
    public record class BasketItemResponse
    {
        public int ProductId { get; init; }

        public string ProductName { get; init; }

        public decimal ProductPrice { get; init; }

        public string Description { get; init; }

        public string[] ProductImages { get; set; }

        public BasketItemResponse(BasketItemDto basketItemDto)
        {
            ProductId = basketItemDto.ProductId;
            ProductName = basketItemDto.ProductName;
            ProductPrice = basketItemDto.ProductPrice;
            Description = basketItemDto.ProductDescription;
            ProductImages = basketItemDto.ProductImages;
        }
    }
}
