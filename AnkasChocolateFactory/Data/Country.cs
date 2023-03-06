namespace AnkasChocolateFactory.Data
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual IList<Factory> Factories { get; set; }

    }
}
