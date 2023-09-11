namespace Catalog
{
    public interface ICatalogProductRepository
    {
        public void Delete(Guid id);
        public void Delete(string sku);
        Product Find(Guid id);
        void Register(Product product);
        void Update(Product product);
    }
}