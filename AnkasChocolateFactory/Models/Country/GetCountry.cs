using AnkasChocolateFactory.Data;
using AnkasChocolateFactory.Models.Factory;

namespace AnkasChocolateFactory.Models.Country;

public class GetCountry : BaseEntity
{
    
    public string Name { get; set; }
    public string ShortName { get; set; }
}

public class GetCountryDetails : BaseEntity
{

    public string Name { get; set; }
    public string ShortName { get; set; }
    public List<FactoryDto> Factories { get; set; }
}

