namespace catalog
{
    public class Product
    {
        public string Description { get; set; }
        public Guid Id { get; }
        public string Name { get; set; }
        public string Sku { get; set; }

        public Product(string description, string name, string sku, Guid id = default)
        {
            Description = description;
            Name = name;
            Sku = sku;
            Id = id == default ? Guid.NewGuid() : id;
        }
    }
}
