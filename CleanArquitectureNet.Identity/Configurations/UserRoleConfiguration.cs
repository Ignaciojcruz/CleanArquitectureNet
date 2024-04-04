using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArquitectureNet.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "70e6936b-9d19-4b84-b8ab-a4d232d951f2",
                    UserId = "8e833c65-502b-4dbf-ad2c-33373ae0fa6a",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "57f29fe6-b5b4-4dc8-adc9-27a95044708e",
                    UserId = "493fa8b4-8d08-45fc-a6e7-90d26df79435",
                }
                );
        }
    }
}
