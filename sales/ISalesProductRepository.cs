namespace Sales
{
    public interface ISalesProductRepository
    {
        public void Delete(Guid id);
        public void Delete(string sku);
        Product Find(Guid id);
        Product Find(string sku);
        void Update(Product product);
    }
}