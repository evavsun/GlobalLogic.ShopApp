namespace GlobalLogic.Basket.Api.Infrastrucure.Exceptions
{
    public class QuantityEqualOrBelowZeroException : Exception
    {
        private const string ErrorMessage = "Qunatity is equal or below zero";

        public QuantityEqualOrBelowZeroException()
            : base(ErrorMessage)
        {
        }

        public QuantityEqualOrBelowZeroException(Exception innerException)
            : base(ErrorMessage, innerException)
        {
        }
    }
}
