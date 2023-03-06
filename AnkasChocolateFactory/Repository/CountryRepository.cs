using AnkasChocolateFactory.Contracts;
using AnkasChocolateFactory.Data;
using Microsoft.EntityFrameworkCore;

namespace AnkasChocolateFactory.Repository;

public class CountryRepository : GenericRepository<Country>, ICountriesRepository
{
    public readonly ChocolateFactoryDbContext _context;
    public CountryRepository(ChocolateFactoryDbContext context) : base(context)
    {
        this._context = context;
    }

   

    public async Task<Country> GetDetails(int id)
    {
       return await _context.Countries.Include(q=>q.Factories)
            .FirstOrDefaultAsync(q => q.Id == id);
    }
}
