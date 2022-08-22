namespace GlobalLogic.ShopApp.Core.AggregatesModel.IdentityUserAggregate
{
    public class ApplicationUser : Entity, IAggregateRoot
    {
        public string Login { get; private set; }

        public string Password { get; private set; }

        public ApplicationUser(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
