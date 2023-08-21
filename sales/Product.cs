namespace Sales
{
    public class Product : Entity
    {
        public Product(decimal? price, string sku, Guid id = default) : base(id)
        {
            Price = price ?? 0;
            Sku = sku;
        }

        public decimal Price { get; set; }
        public string Sku { get; }

        public void SetPrice(decimal price)
        {
            Price = price;
        }
    }
}