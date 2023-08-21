namespace Warehouse.Infrastructure.Read
{
    public interface IWarehouseReadService
    {
        public Product Find(Guid id);
    }
}
