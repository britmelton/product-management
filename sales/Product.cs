namespace Sales
{
    public class Product
    {
        public Product(decimal price, string sku)
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