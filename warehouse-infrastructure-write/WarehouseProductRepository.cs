namespace Warehouse.Infrastructure.Write
{
    public class WarehouseProductRepository : IWarehouseProductRepository
    {
        private readonly Context _context;

        public WarehouseProductRepository(Context context)
        {
            this._context = context;
        }

        public Warehouse.Product Find(Guid id) => _context.Product.Find(id);

        public void Update(Warehouse.Product product)
        {
            var storedProduct = _context.Product.Find(product.Id);

            storedProduct.Update(product);

            _context.Product.Update(storedProduct);
            _context.SaveChanges();
        }
    }
}
