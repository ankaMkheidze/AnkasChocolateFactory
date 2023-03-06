using Microsoft.Build.Framework;

namespace AnkasChocolateFactory.Models.Factory;

public abstract class BaseFactory
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    public double? Rating { get; set; }
    [Required]
    public int CountryId { get; set; }
}
