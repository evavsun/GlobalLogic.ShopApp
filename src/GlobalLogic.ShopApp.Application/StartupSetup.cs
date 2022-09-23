using GlobalLogic.ShopApp.Application.Identity.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GlobalLogic.ShopApp.Application
{
    public static class StartupSetup
    {
        public static void AddAuthentication(this IServiceCollection services, JwtOptions jwtOptions)
        {
            services.AddSingleton(provider => {
                RSA rsa = RSA.Create();
                rsa.ImportRSAPublicKey(
                    source: Convert.FromBase64String(jwtOptions.PublicKey),
                    bytesRead: out int _
                );

                return new RsaSecurityKey(rsa);
            });

            services.Configure<JwtOptions>(x =>
            {
                x.Issuer = jwtOptions.Issuer;
                x.Audience = jwtOptions.Audience;
                x.Lifetime = jwtOptions.Lifetime;
                x.PublicKey = jwtOptions.PublicKey;
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    SecurityKey rsa = services.BuildServiceProvider().GetRequiredService<RsaSecurityKey>();

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
