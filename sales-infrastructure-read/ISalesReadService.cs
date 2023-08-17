namespace Sales.Infrastructure.Read
{
    public interface ISalesReadService
    {
        public Product Find(Guid id);
    }
}
