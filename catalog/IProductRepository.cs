namespace Catalog
{
    public interface IProductRepository
    {
        Product Find(Guid id);
        void Register(Product product);
        void Update(Product product);
    }
}