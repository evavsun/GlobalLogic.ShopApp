using Autofac;
using GlobalLogic.ShopApp.Application.Identity;
using GlobalLogic.ShopApp.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GlobalLogic.ShopApp.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // IPasswordHasher<ApplicationUser>
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            // builder.RegisterType<PasswordHasher>().As<IPasswordHasher>().SingleInstance();
            builder.RegisterType<TokenProvider>().As<ITokenProvider>().SingleInstance();
            builder.RegisterGeneric(typeof(PasswordHasher<>)).As(typeof(IPasswordHasher<>)).SingleInstance();
        }
    }
}
