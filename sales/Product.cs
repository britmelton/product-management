namespace Sales
{
    public class Product
    {
        public Product(decimal price, string sku, Guid id)
        {
            Price = price;
            Sku = sku;
            Id = id;
        }

        public Guid Id { get; }
        public decimal Price { get; set; }
        public string Sku { get; }

        public void AdjustPrice(decimal price)
        {
            Price = price;
        }
    }
}