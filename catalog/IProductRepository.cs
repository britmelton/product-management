namespace catalog
{
    public interface IProductRepository
    {
        Product Find(Guid id);
        void Register(Product product);
    }
}
