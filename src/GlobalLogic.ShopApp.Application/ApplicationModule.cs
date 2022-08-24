using Autofac;
using GlobalLogic.ShopApp.Application.Identity;
using GlobalLogic.ShopApp.Core.Interfaces;

namespace GlobalLogic.ShopApp.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<PasswordHasher>().As<IPasswordHasher>().SingleInstance();
            builder.RegisterType<TokenProvider>().As<ITokenProvider>().SingleInstance();
        }
    }
}
