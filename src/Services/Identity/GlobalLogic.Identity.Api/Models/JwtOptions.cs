namespace GlobalLogic.Identity.Api.Models
{
    public class JwtOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string PrivateKey { get; set; }

        public int Lifetime { get; set; }
    }
}
