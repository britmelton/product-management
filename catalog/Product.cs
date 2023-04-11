namespace catalog
{
    public class Product
    {
        public string Description { get; set; }
        public string Name { get; set; }

        public Product(string description, string name)
        {
            Description = description;
            Name = name;
        }
    }
}
