namespace GlobalLogic.Identity.Api.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        private const string ErrorMessage = "User already exist";

        public UserAlreadyExistsException()
            : base(ErrorMessage)
        {
        }

        public UserAlreadyExistsException(Exception innerException)
            : base(ErrorMessage, innerException)
        {
        }
    }
}
