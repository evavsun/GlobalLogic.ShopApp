using Autofac;
using GlobalLogic.ShopApp.Core.AggregatesModel.ApplicationUserAggregate;
using GlobalLogic.ShopApp.Core.AggregatesModel.OrderAggregate;
using GlobalLogic.ShopApp.Core.AggregatesModel.ProductAggregate;
using GlobalLogic.ShopApp.Infrastructure.Data;

namespace GlobalLogic.ShopApp.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IApplicationUserRepository>().As<ApplicationUserRepository>().SingleInstance();
            builder.RegisterType<IProductRepository>().As<ProductRepository>().SingleInstance();
            builder.RegisterType<IOrderRepository>().As<OrderRepository>().SingleInstance();
        }
    }
}
