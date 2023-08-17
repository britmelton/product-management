namespace Catalog.Infrastructure.Read
{
    public interface ICatalogReadService
    {
        public Product Find(Guid id);
    }
}