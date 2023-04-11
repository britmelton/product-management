namespace catalog
{
    public class Product
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }

        public Product(string description, string name, string sku)
        {
            Description = description;
            Name = name;
            Sku = sku;
        }
    }
}
