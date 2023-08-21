namespace Warehouse
{
    public class Product : Entity
    {
        public Product(string description, string name, int qty, string sku, Guid id = default) : base(id)
        {
            Description = description;
            Name = name;
            Quantity = qty;
            Sku = sku;
        }

        public string Description { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; }

        public void Receive(int qty)
        {
            Quantity += qty;
        }

        public void Ship(int qty)
        {
            Quantity -= qty;
        }
    }
}
