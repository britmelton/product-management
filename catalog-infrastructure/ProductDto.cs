using catalog;

namespace catalog_infrastructure
{
    public class ProductDto : Entity
    {
        public ProductDto()
        {
        }

        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsStaged { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }

        public ProductDto(Product product) : base(product.Id)
        {
            Description = product.Description;
            IsActive = product.IsActive;
            IsStaged = product.IsStaged;
            Name = product.Name;
            Sku = product.Sku;
        }

        public ProductDto Update(Product product)
        {
            IsActive = product.IsActive;
            IsStaged = product.IsStaged;
            Description = product.Description;
            Name = product.Name;

            return this;
        }
    }
}
