using AnkasChocolateFactory.Data;

namespace AnkasChocolateFactory.Contracts;

public interface ICountriesRepository : IGenericRepository<Country>
{
    Task<Country> GetDetails(int id);
    
}

