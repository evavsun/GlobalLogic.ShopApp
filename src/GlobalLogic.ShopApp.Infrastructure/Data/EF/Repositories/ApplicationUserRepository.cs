using System.Linq.Expressions;
using GlobalLogic.ShopApp.Core.AggregatesModel.ApplicationUserAggregate;
using Microsoft.EntityFrameworkCore;

namespace GlobalLogic.ShopApp.Infrastructure.Data
{
    internal class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly AppDbContext _dbContext;

        public ApplicationUserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ApplicationUser user)
        {
            await _dbContext.ApplicationUsers.AddAsync(user);
        }

        public Task<ApplicationUser?> GetAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return _dbContext.ApplicationUsers.FirstOrDefaultAsync(predicate);
        }
    }
}
