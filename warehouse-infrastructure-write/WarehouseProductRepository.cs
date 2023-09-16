using System.Linq.Expressions;

namespace Warehouse.Infrastructure.Write
{
    public class WarehouseProductRepository : IWarehouseProductRepository
    {
        private readonly Context _context;

        public WarehouseProductRepository(Context context)
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

        private Warehouse.Product Find(Expression<Func<Product, bool>> predicate) => _context.Product.First(predicate);
        public Warehouse.Product Find(Guid id) => Find(x => x.Id == id);
        public Warehouse.Product Find(string sku) => Find(x => x.Sku == sku);
        private Product FindInf(Expression<Func<Product, bool>> predicate) => _context.Product.First(predicate);
        public Product FindInf(Guid id) => FindInf(x => x.Id == id);
        public Product FindInf(string sku) => FindInf(x => x.Sku == sku);

        public void Update(Warehouse.Product product)
        {
            var storedProduct = _context.Product.Find(product.Id);

            storedProduct.Update(product);

            _context.Product.Update(storedProduct);
            _context.SaveChanges();
        }
    }
}
