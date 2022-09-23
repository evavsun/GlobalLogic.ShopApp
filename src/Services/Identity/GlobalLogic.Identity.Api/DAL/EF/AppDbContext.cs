using GlobalLogic.Identity.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalLogic.Identity.Api.DAL.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
