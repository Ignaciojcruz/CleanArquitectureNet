using CleanArquitectureNet.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArquitectureNet.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "8e833c65-502b-4dbf-ad2c-33373ae0fa6a",
                    Email = "admin@example.com",
                    NormalizedEmail = "admin@example.com",
                    Nombre = "Ignacio",
                    Apellidos = "Cruz",
                    UserName = "admin@example.com",
                    NormalizedUserName = "admin@example.com",
                    PasswordHash = hasher.HashPassword(null, "admin1234$"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "493fa8b4-8d08-45fc-a6e7-90d26df79435",
                    Email = "juanperez@example.com",
                    NormalizedEmail = "juanperez@example.com",
                    Nombre = "Juan",
                    Apellidos = "Perez",
                    UserName = "juanperez@example.com",
                    NormalizedUserName = "juanperez@example.com",
                    PasswordHash = hasher.HashPassword(null, "admin1234$%"),
                    EmailConfirmed = true,
                }
                );
        }
    }
}
