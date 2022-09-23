namespace GlobalLogic.Identity.Api.Abstractions.Repositories
{
    public interface IApplicationUserRepository
    {
        Task AddAsync(ApplicationUser user);

        Task<ApplicationUser> GetAsync(string email);

        Task SaveChangesAsync();
    }
}
