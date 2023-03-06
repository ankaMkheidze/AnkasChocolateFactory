using AnkasChocolateFactory.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AnkasChocolateFactory.Data;

public class ChocolateFactoryDbContext :IdentityDbContext<ApiUser>
{
    public ChocolateFactoryDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Factory> Factories { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new CountryConfiguration());
        builder.ApplyConfiguration(new FactoryConfiguration());
        
        
    }
}
