using Autofac;
using GlobalLogic.ShopApp.Application.Identity;
using GlobalLogic.ShopApp.Application.Services;
using GlobalLogic.ShopApp.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace GlobalLogic.ShopApp.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorizationService>().As<IAuthorizationService>().SingleInstance();
            builder.RegisterType<TokenProvider>().As<ITokenProvider>().SingleInstance();
            builder.RegisterGeneric(typeof(PasswordHasher<>)).As(typeof(IPasswordHasher<>)).SingleInstance();
            builder.RegisterType<OrderService>().As<IOrderService>().SingleInstance();
            builder.RegisterType<MemoryCache>().As<IMemoryCache>().SingleInstance();
        }
    }
}
