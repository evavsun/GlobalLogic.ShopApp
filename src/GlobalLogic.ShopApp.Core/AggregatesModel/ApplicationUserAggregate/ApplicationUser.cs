using GlobalLogic.ShopApp.Core.Exceptions;

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

        public async Task SetLoginAsync(string login, IApplicationUserRepository applicationUserRepository)
        {
            var userExists = (await applicationUserRepository.GetAsync(login)) is not null;
            if (userExists)
                throw new UserAlreadyExistsException();
            Login = login;
        }
    }
}
