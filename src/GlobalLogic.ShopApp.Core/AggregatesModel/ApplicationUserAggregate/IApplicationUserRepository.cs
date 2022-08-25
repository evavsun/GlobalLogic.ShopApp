using System.Linq.Expressions;

namespace GlobalLogic.ShopApp.Core.AggregatesModel.ApplicationUserAggregate
{
    public interface IApplicationUserRepository
    {
        Task AddAsync(ApplicationUser user);

        Task<ApplicationUser?> GetAsync(Expression<Func<ApplicationUser, bool>> predicate);
    }
}
