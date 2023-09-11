namespace Catalog.Infrastructure.Write
{
    public class Product : Entity
    {
        public Product()
        { }

        public Product(Catalog.Product product) : base(product.Id)
        {
            Description = product.Description;
            IsActive = product.Status.HasFlag(ProductStatus.Activated);
            IsStaged = product.Status.HasFlag(ProductStatus.Staged);
            Name = product.Name;
            Sku = product.Sku;
        } 

        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsStaged { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }

        public static implicit operator Catalog.Product(Product source)
        {
            var status = ProductStatus.Deactivated;

            if (source.IsStaged)
                status = ProductStatus.Staged;
            else if (source.IsActive)
                status = ProductStatus.Activated;
            
            return new(source.Description, source.Name, source.Sku, status, source.Id);
        }

        public static implicit operator Product(Catalog.Product source) =>
            new(source);

        public Product Update(Catalog.Product product)
        {
            IsActive = product.Status.HasFlag(ProductStatus.Activated);
            IsStaged = product.Status.HasFlag(ProductStatus.Staged);
            Description = product.Description;
            Name = product.Name;

            return this;
        }
    }
}