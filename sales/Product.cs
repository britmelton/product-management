namespace Sales
{
    public class Product : Entity
    {
        public Product(decimal price, string sku, Guid id = default) : base(id)
        {
            Price = price;
            Sku = sku;
        }

        public decimal Price { get; set; }
        public string Sku { get; }

        public void AdjustPrice(decimal price)
        {
            Price = price;
        }
    }
}