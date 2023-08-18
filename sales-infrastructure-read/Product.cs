namespace Sales.Infrastructure.Read
{
    public class Product
    {
        public Guid Id { get; }
        public decimal? Price { get; init; }
        public string Sku { get; }
    }
}