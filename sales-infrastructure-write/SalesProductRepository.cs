using System.Linq.Expressions;

namespace Sales.Infrastructure.Write
{
    public class SalesProductRepository : ISalesProductRepository 
    {
        private readonly Context _context;

        public SalesProductRepository(Context context)
        {
            this._context = context;
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

        private Sales.Product Find(Expression<Func<Product, bool>> predicate) => _context.Product.First(predicate);
        public Sales.Product Find(Guid id) => Find(x => x.Id == id);
        private Product FindInf(Expression<Func<Product, bool>> predicate) => _context.Product.First(predicate);
        public Product FindInf(Guid id) => FindInf(x => x.Id == id);
        public Product FindInf(string sku) => FindInf(x => x.Sku == sku);

        public void Update(Sales.Product product)
        {
            var storedProduct = _context.Product.Find(product.Id);

            storedProduct.Update(product);

            _context.Product.Update(storedProduct);
            _context.SaveChanges();
        }
    }
}