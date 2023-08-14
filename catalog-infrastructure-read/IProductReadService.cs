namespace Catalog.Infrastructure.Read
{
    public interface IProductReadService
    {
        public Product Find(Guid id);
    }
}