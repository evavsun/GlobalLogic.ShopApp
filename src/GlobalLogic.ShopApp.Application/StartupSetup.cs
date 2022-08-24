using GlobalLogic.ShopApp.Application.Identity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GlobalLogic.ShopApp.Application
{
    public static class StartupSetup
    {
        public static void AddAuthentication(this IServiceCollection services, AuthOptions authOptions)
        {
            services.Configure<AuthOptions>(x =>
            {
                x.Issuer = authOptions.Issuer;
                x.Audience = authOptions.Audience;
                x.Lifetime = authOptions.Lifetime;
                x.Key = authOptions.Key;
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                    };
                });
        }
    }
}
