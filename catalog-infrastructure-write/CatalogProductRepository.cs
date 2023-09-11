using System.Linq.Expressions;

namespace Catalog.Infrastructure.Write
{
    public class CatalogProductRepository : ICatalogProductRepository
    {
        private readonly Context _context;

        public CatalogProductRepository(Context context)
        {
            _context = context;
        }

        public void Delete(Guid id)
        {
            var storedProduct = FindInf(id);

            _context.Product.Remove(storedProduct);
            _context.SaveChanges();
        }

        public void Delete(string sku)
        {
            var storedProduct = FindInf(sku);

            _context.Product.Remove(storedProduct);
            _context.SaveChanges();
        }

        public bool Exists(string sku) => _context.Product.Any(x => x.Sku == sku);

        private Catalog.Product Find(Expression<Func<Product, bool>> predicate) => _context.Product.First(predicate);
        public Catalog.Product Find(Guid id) => Find(x => x.Id == id);

        private Product FindInf(Expression<Func<Product, bool>> predicate) => _context.Product.First(predicate);
        public Product FindInf(Guid id) => FindInf(x => x.Id == id);
        public Product FindInf(string sku) => FindInf(x => x.Sku == sku);

        public void Register(Catalog.Product product)
        {
            if (Exists(product.Sku))
            {
                //handle error
            }
            var dbProduct = new Product(product);
            _context.Product.Add(dbProduct);
            _context.SaveChanges();
        }

        public void Update(Catalog.Product product)
        {
            var storedProduct = FindInf(product.Id);

            storedProduct.Update(product);

            //_context.Product.Update(storedProduct);
            _context.SaveChanges();
        }
    }
}
