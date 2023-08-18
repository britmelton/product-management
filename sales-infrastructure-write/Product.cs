using Microsoft.EntityFrameworkCore;

namespace Sales.Infrastructure.Write
{
    public class Product : Entity
    {
        public Product()
        { }

        public Product(Sales.Product product) : base(product.Id)
        {
            Price = product.Price;
            Sku = product.Sku;
        }
        [Precision(6, 2)]
        public decimal? Price { get; set; }
        public string Sku { get;  }

        public static implicit operator Sales.Product(Product source) => new(source.Price, source.Sku, source.Id);

        public static implicit operator Product(Sales.Product source) =>
            new(source);

        public Product Update(Sales.Product product)
        {
            Price = product.Price;

            return this;
        }
    }
}