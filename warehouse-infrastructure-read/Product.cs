namespace Warehouse.Infrastructure.Read
{
    public class Product
    {
        public Guid Id { get; }
        public string Description { get; }
        public string Name { get; }
        public int Quantity { get; init; }
        public string Sku { get; }
    }
}