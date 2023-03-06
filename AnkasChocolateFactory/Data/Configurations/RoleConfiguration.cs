using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnkasChocolateFactory.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "boss",
                    NormalizedName= "BOSS"
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
             );
        }
    }
}
