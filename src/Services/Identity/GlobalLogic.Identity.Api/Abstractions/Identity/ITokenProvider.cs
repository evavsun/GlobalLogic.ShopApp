namespace GlobalLogic.Identity.Api.Abstractions.Identity
{
    public interface ITokenProvider
    {
        JwtResult GetToken(ApplicationUser user);
    }
}
