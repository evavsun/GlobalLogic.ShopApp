using Autofac;
using GlobalLogic.ShopApp.Core.AggregatesModel.BasketAggregate;
using GlobalLogic.ShopApp.Core.Interfaces;
using GlobalLogic.ShopApp.Infrastructure.Data.EF;
using GlobalLogic.ShopApp.Infrastructure.Data.MemoryCache;

namespace GlobalLogic.ShopApp.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<BasketStore>().As<IBasketStore>().SingleInstance();
        }
    }
}
