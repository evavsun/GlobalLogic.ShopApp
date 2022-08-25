namespace GlobalLogic.ShopApp.Core.Exceptions
{
    public class ProductPriceException : Exception
    {
        private const string ErrorMessage = "The price cannot be less than zero";

        public ProductPriceException()
            : base(ErrorMessage)
        {
        }

        public ProductPriceException(Exception innerException)
            : base(ErrorMessage, innerException)
        {

        }
    }
}
