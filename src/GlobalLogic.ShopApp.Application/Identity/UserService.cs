using GlobalLogic.ShopApp.Core.AggregatesModel.ApplicationUserAggregate;
using GlobalLogic.ShopApp.Core.Interfaces;

namespace GlobalLogic.ShopApp.Application.Identity
{
    public class UserService : IUserService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        private readonly IPasswordHasher _passwordHasher;

        private readonly ITokenProvider _tokenProvider;

        public UserService(IApplicationUserRepository applicationUserRepository, IPasswordHasher passwordHasher, ITokenProvider tokenProvider)
        {
            _applicationUserRepository = applicationUserRepository;
            _passwordHasher = passwordHasher;
            _tokenProvider = tokenProvider;
        }

        public async Task<string> LoginAsync(string login, string password)
        {
            var dbUser = await _applicationUserRepository.GetAsync(u => u.Login == login);
            if (dbUser == null)
                throw new Exception("Uset in not exist");
            var isVerified = _passwordHasher.VerifyPassword(dbUser.Password, password);
            if (isVerified)
                return _tokenProvider.GetToken(dbUser);
            throw new Exception("Login or password is incorrect");

        }

        public async Task RegisterAsync(string login, string password)
        {
            var dbUser = await _applicationUserRepository.GetAsync(u => u.Login == login);
            if (dbUser is not null)
                throw new Exception("This user already exist");
            var hashedPassword = _passwordHasher.HashPassword(password);
            await _applicationUserRepository.AddAsync(new ApplicationUser(login, hashedPassword));
        }
    }
}
