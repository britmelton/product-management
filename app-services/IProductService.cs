namespace app_services;
public interface IProductService
{
    public Guid Register(RegisterProductCommand args);
}
