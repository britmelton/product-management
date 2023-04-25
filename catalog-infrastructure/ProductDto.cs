using catalog;

namespace catalog_infrastructure
{
    public class ProductDto : Entity
    {
        public ProductDto()
        {
        }

        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ProductDto(Product product) : base(product.Id)
        {
            Sku = product.Sku;
            Name = product.Name;
            Description = product.Description;
            
        }
    }
}
