namespace GlobalLogic.Identity.Api.Exceptions
{
    public class LoginOrPasswordIncorrectException : Exception
    {
        private const string ErrorMessage = "Login or password is incorrect";

        public LoginOrPasswordIncorrectException()
            : base(ErrorMessage)
        {
        }

        public LoginOrPasswordIncorrectException(Exception innerException)
            : base(ErrorMessage, innerException)
        {
        }
    }
}
