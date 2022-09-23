namespace GlobalLogic.Identity.Api.DAL.Respositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly AppDbContext _dbContext;

        public ApplicationUserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ApplicationUser user) =>
            await _dbContext.ApplicationUsers.AddAsync(user);
        

        public async Task<ApplicationUser> GetAsync(string email) =>
            await _dbContext.ApplicationUsers.FirstOrDefaultAsync(x => x.Email == email);

        public async Task SaveChangesAsync() =>
            await _dbContext.SaveChangesAsync();
    }
}
