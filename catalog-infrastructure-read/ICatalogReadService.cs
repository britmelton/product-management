namespace Catalog.Infrastructure.Read
{
    public interface ICatalogReadService
    {
        public Product Find(string sku);
        public Product Find(Guid id);
    }
}