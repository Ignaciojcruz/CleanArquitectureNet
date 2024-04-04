using CleanArquitectureNet.Identity.Configurations;
using CleanArquitectureNet.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArquitectureNet.Identity
{
    public class CleanArquitectureNetIdentityDBContext : IdentityDbContext<ApplicationUser>
    {
        public CleanArquitectureNetIdentityDBContext(DbContextOptions<CleanArquitectureNetIdentityDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
