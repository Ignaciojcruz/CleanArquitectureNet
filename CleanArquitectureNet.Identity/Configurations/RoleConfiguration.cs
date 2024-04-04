using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArquitectureNet.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "70e6936b-9d19-4b84-b8ab-a4d232d951f2",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                },
                new IdentityRole
                {
                    Id = "57f29fe6-b5b4-4dc8-adc9-27a95044708e",
                    Name = "Operator",
                    NormalizedName = "OPERATOR",
                }
                );
        }
    }
}
