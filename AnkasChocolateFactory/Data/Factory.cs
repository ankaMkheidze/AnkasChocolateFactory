using System.ComponentModel.DataAnnotations.Schema;

namespace AnkasChocolateFactory.Data;

public class Factory : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public double Rating { get; set; }
    //Esea uketesi imitoro tu shecvli saxels ar ikneba problema
    [ForeignKey(nameof(CountryId))]
    public int CountryId { get; set; }
    public Country Country { get; set; }
}
