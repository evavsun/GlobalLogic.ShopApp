namespace GlobalLogic.ShopApp.Core.AggregatesModel.ApplicationUserAggregate
{
    public class ApplicationUser : Entity, IAggregateRoot
    {
        public string Login { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public ApplicationUser()
        {
        }

        public void SetPassword(string password) =>
            Password = password;

        public string SetLogin(string login) =>
            Login = login;
    }
}
