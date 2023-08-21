using Microsoft.EntityFrameworkCore;

namespace Warehouse.Infrastructure.Write
{
    public class Product : Entity
    {
        public Product()
        { }

        public Product(Warehouse.Product product) : base(product.Id)
        {
            Description = product.Description;
            Name = product.Name;
            Quantity = product.Quantity;
            Sku = product.Sku;
        }
        public string Description { get; }
        public string Name { get; }
        public int Quantity { get; set; }
        public string Sku { get; }

        public static implicit operator Warehouse.Product(Product source) => new(source.Description, source.Name, source.Quantity, source.Sku, source.Id);

        public static implicit operator Product(Warehouse.Product source) =>
            new(source);

        public Product Update(Warehouse.Product product)
        {
            Quantity = product.Quantity;

            return this;
        }
    }
}
