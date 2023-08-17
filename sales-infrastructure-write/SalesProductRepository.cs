namespace Sales.Infrastructure.Write
{
    public class SalesProductRepository : ISalesProductRepository 
    {
        private readonly Context _context;

        public SalesProductRepository(Context context)
        {
            this._context = context;
        }

        public Sales.Product Find(Guid id) => _context.Product.Find(id);

        public void Update(Sales.Product product)
        {
            var storedProduct = _context.Product.Find(product.Id);

            storedProduct.Update(product);

            _context.Product.Update(storedProduct);
            _context.SaveChanges();
        }
    }
}