namespace GlobalLogic.Identity.Api.Exceptions
{
    public class UserDoesNotExistException : Exception
    {
        private const string ErrorMessage = "User does not exist with such a Login";

        public UserDoesNotExistException()
            : base(ErrorMessage)
        {
        }

        public UserDoesNotExistException(Exception innerException)
            : base(ErrorMessage, innerException)
        {
        }
    }
}
