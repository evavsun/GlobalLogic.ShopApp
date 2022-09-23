namespace GlobalLogic.Basket.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static AuthenticationBuilder AddJwtAuthentication(this IServiceCollection services, JwtOptions jwtOptions)
        {
            services.AddSingleton(provider => {
                 RSA rsa = RSA.Create();
                 rsa.ImportRSAPublicKey(
                     source: Convert.FromBase64String(jwtOptions.PublicKey),
                     bytesRead: out int _
                 );

                 return new RsaSecurityKey(rsa);
             });

            return services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var provider = services.BuildServiceProvider();
                    var rsa = provider.GetRequiredService<RsaSecurityKey>();

                    options.IncludeErrorDetails = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = rsa,
                        ValidAudience = jwtOptions.Audience,
                        ValidIssuer = jwtOptions.Issuer,
                        RequireSignedTokens = true,
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                    };
                });
        }
    }
}
