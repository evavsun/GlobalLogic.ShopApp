namespace GlobalLogic.Identity.Api.Models
{
    public class JwtResult
    {
        public string Token { get; set; }
        public long UnixTimeExpiresAt { get; set; }
    }
}
