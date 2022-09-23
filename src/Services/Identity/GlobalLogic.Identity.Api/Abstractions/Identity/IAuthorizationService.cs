namespace GlobalLogic.Identity.Api.Abstractions.Identity
{
    public interface IAuthorizationService
    {
        Task RegisterAsync(RegisterRequestModel request);

        Task<JwtResult> LoginAsync(LoginRequestModel request);
    }
}
