using Autofac;
using GlobalLogic.ShopApp.Application.Identity;
using GlobalLogic.ShopApp.Core.Interfaces;

namespace GlobalLogic.ShopApp.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IUserService>().As<UserService>().SingleInstance();
            builder.RegisterType<IPasswordHasher>().As<PasswordHasher>().SingleInstance();
            builder.RegisterType<ITokenProvider>().As<TokenProvider>().SingleInstance();
        }
    }
}
