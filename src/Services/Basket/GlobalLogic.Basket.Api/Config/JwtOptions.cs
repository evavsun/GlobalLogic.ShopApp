namespace GlobalLogic.Basket.Api.Config
{
    public class JwtOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string PublicKey { get; set; }

        public int Lifetime { get; set; }
    }
}
