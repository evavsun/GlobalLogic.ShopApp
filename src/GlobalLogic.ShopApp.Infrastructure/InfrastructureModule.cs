using Autofac;
using GlobalLogic.ShopApp.Core.Interfaces;
using GlobalLogic.ShopApp.Infrastructure.Data.EF;

namespace GlobalLogic.ShopApp.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
