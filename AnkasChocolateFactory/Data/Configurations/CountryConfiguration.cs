using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnkasChocolateFactory.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = 1,
                    Name = "Georgia",
                    ShortName = "GEO"
                });
        }
    }
}
