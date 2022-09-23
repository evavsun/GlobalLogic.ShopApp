namespace GlobalLogic.Identity.Api.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IApplicationUserRepository _userRepository;

        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        private readonly ITokenProvider _tokenProvider;

        public AuthorizationService(IApplicationUserRepository userRepository,
            IPasswordHasher<ApplicationUser> passwordHasher,
            ITokenProvider tokenProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenProvider = tokenProvider;
        }

        public async Task<JwtResult> LoginAsync(LoginRequestModel request)
        {
            var dbUser = await _userRepository.GetAsync(request.Email);
            if (dbUser == null)
                throw new UserDoesNotExistException();
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(dbUser, dbUser.Password, request.Password);
            if (passwordVerificationResult == PasswordVerificationResult.Success)
                return _tokenProvider.GetToken(dbUser);
            throw new LoginOrPasswordIncorrectException();
        }

        public async Task RegisterAsync(RegisterRequestModel request)
        {
            var newUser = new ApplicationUser();
            await newUser.SetEmailAsync(request.Email, _userRepository);
            var hashedPassword = _passwordHasher.HashPassword(newUser, request.Password);
            newUser.SetPassword(hashedPassword);
            newUser.SetPhoneNumber(request.PhoneNumber);
            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();
        }
    }
}
