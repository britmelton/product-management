namespace Sales
{
    public interface ISalesProductRepository
    {
        Product Find(Guid id);
        void Update(Product product);
    }
}