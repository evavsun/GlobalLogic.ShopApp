namespace GlobalLogic.Identity.Api.Services
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IOptions<JwtOptions> _jwtOptions;

        public TokenProvider(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public JwtResult GetToken(ApplicationUser user)
        {
            var jwtOptions = _jwtOptions.Value;
            using var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(
                source: Convert.FromBase64String(jwtOptions.PrivateKey),
                bytesRead: out int _);
            var signingCredentials = new SigningCredentials(
                key: new RsaSecurityKey(rsa),
                algorithm: SecurityAlgorithms.RsaSha256
            )
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                audience: jwtOptions.Audience,
                issuer: jwtOptions.Issuer,
                claims: new Claim[] { new Claim(ClaimTypes.Name, user.Email) },
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(jwtOptions.Lifetime)),
                signingCredentials: signingCredentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new JwtResult { Token = token, UnixTimeExpiresAt = new DateTimeOffset(now).ToUnixTimeMilliseconds() };
        }
    }
}
