namespace Sales.Infrastructure.Read
{
    public class Product
    {
        public Guid Id { get; }
        public decimal Price { get; set; }
        public string Sku { get; }
    }
}