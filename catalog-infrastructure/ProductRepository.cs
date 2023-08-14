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

        public catalog.Product Find(Guid id) => _context.Product.Find(id);

        public void Register(catalog.Product product)
        {
            var dbProduct = new Product(product);
            _context.Product.Add(dbProduct);
            _context.SaveChanges();
        }

        public void Update(catalog.Product product)
        {
            var storedProduct = _context.Product.Find(product.Id);

            storedProduct.Update(product);

            _context.Product.Update(storedProduct);
            _context.SaveChanges();
        }
    }
}
