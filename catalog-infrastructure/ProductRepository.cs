using catalog;

namespace catalog_infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            this._context = context;
        }

        public Product Find(Guid id)
        {
            var dbProduct = _context.Product.Find(id);
            var product = new Product(dbProduct.Description, dbProduct.Name, dbProduct.Sku, dbProduct.Id);
            return product;
        }

        public void Register(Product product)
        {
            var dbProduct = new ProductDto(product);
            _context.Product.Add(dbProduct);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            ProductDto storedProduct = _context.Product.Find(product.Id);

            storedProduct.Update(product);

            _context.Product.Update(storedProduct);
            _context.SaveChanges();
        }
    }
}
