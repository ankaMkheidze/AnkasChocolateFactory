using Microsoft.Build.Framework;

namespace AnkasChocolateFactory.Models.Country;

public class CreateCountry
{
    [Required]
    public string Name { get; set; }
    public string ShortName { get; set; }
}
