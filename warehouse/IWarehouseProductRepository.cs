namespace Warehouse
{
    public interface IWarehouseProductRepository
    {
        public void Delete(Guid id);
        public void Delete(string sku);
        Product Find(Guid id);
        void Update(Product product);
    }
}
