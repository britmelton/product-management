using catalog;

namespace app_services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }
    public Guid Register(RegisterProductCommand args)
    {
        var (name, description, sku) = args;
        var product = new Product(name, description, sku);
        _repo.Register(product);
        return product.Id;
    }
}