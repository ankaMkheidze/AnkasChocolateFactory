using AnkasChocolateFactory.Data;
using Microsoft.Build.Framework;

namespace AnkasChocolateFactory.Models.Country
{
    public class UpdateCountry : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
