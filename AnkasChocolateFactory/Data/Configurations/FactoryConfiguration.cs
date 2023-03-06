using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnkasChocolateFactory.Data.Configurations
{
    public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
    {
        public void Configure(EntityTypeBuilder<Factory> builder)
        {
            builder.HasData(
                new Factory
                {
                    Id = 1,
                    Name = "Barambo",
                    Address = "Paliashvili",
                    CountryId = 1
                });
        }
    }
}
