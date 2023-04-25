namespace catalog
{
    public class Product
    {
        public string Description { get; set; }
        public Guid Id { get; }
        public string Name { get; set; }
        public Sku Sku { get; set; }

        public Product(string description, string name, Sku sku, Guid id = default)
        {
            Description = description;
            Name = name;
            Sku = sku;
            Id = id == default ? Guid.NewGuid() : id;
        }

        public string EditName(string newName)
        {
            Name = newName;
            return Name;
        }
    }
}
