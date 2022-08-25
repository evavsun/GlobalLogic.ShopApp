using GlobalLogic.ShopApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalLogic.ShopApp.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddAppDbContext(this IServiceCollection services, string connectionString) =>
          services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(connectionString));
    }
}
