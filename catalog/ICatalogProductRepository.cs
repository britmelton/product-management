namespace Catalog
{
    public interface ICatalogProductRepository
    {
        Product Find(Guid id);
        void Register(Product product);
        void Update(Product product);
    }
}