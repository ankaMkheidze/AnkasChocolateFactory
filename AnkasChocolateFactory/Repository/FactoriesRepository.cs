using AnkasChocolateFactory.Contracts;
using AnkasChocolateFactory.Data;

namespace AnkasChocolateFactory.Repository
{
    public class FactoriesRepository : GenericRepository<Factory>, IFactoriesRepository
    {
        public FactoriesRepository(ChocolateFactoryDbContext context) : base(context)
        {
        }
    }
}
