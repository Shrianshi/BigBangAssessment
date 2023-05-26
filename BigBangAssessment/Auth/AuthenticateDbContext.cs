using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssessment.Auth
{
    public class AuthenticateDbContext: IdentityDbContext<IdentityUser>
    {
        public AuthenticateDbContext(DbContextOptions<AuthenticateDbContext> options) : base(options)
        {

        }
        public DbSet<RegisterUser> RegisterUser { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
