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
            builder.RegisterType<ApplicationUserRepository>().As<IApplicationUserRepository>().SingleInstance();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();
        }
    }
}
