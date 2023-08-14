namespace catalog.infrastructure.read
{
    public interface IProductReadService
    {
        public Product Find(Guid id);
    }
}
