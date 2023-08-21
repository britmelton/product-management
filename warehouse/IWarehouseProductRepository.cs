namespace Warehouse
{
    public interface IWarehouseProductRepository
    {
        Product Find(Guid id);
        void Update(Product product);
    }
}
