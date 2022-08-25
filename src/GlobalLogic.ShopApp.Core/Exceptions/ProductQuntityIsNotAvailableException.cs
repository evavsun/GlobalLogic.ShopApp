namespace GlobalLogic.ShopApp.Core.Exceptions
{
    public class ProductQuntityIsNotAvailableException : Exception
    {
        public ProductQuntityIsNotAvailableException(string message)
            : base(message)
        {

        }

        public ProductQuntityIsNotAvailableException(string message, Exception innerException)
            :base(message, innerException)
        {

        }
    }
}
