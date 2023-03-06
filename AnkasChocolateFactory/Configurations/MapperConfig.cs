using AnkasChocolateFactory.Data;
using AnkasChocolateFactory.Models.Country;
using AnkasChocolateFactory.Models.Factory;
using AnkasChocolateFactory.Models.Users;
using AutoMapper;
using Microsoft.Build.Framework.Profiler;

namespace AnkasChocolateFactory.Configurations;

public class MapperConfig :Profile
{
	public MapperConfig()
	{
		CreateMap<Country, CreateCountry>().ReverseMap();
		CreateMap<Country, GetCountry>().ReverseMap();
        CreateMap<Country, GetCountryDetails>().ReverseMap();
        CreateMap<Country, UpdateCountry>().ReverseMap();

        CreateMap<Factory, FactoryDto>().ReverseMap();
        CreateMap<Factory, CreateFactory>().ReverseMap();

        CreateMap<ApiUser, ApiUserDto>().ReverseMap();
    }
}
