using GlobalLogic.Identity.Api.Abstractions.Repositories;
using GlobalLogic.Identity.Api.Exceptions;

namespace GlobalLogic.Identity.Api.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        public string Email { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public string PhoneNumber { get; private set; }

        public ApplicationUser()
        {
        }

        public void SetPassword(string password) =>
            Password = password;

        public void SetPhoneNumber(string phoneNumber) =>
            PhoneNumber = phoneNumber;

        public async Task SetEmailAsync(string email, IApplicationUserRepository applicationUserRepository)
        {
            var userExists = (await applicationUserRepository.GetAsync(email)) is not null;
            if (userExists)
                throw new UserAlreadyExistsException();
            Email = email;
        }
    }
}
