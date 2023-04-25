using catalog;

namespace app_services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public void EditDescription(EditDescriptionCommand args)
    {
        var (id, description) = args;

        var product = _repo.Find(id);
        product.EditDescription(description);

        _repo.Update(product);
    }

    public void EditName(EditNameCommand args)
    {
        var (id, name) = args;

        var product = _repo.Find(id);
        product.EditName(name);

        _repo.Update(product);
    }

    public Guid Register(RegisterProductCommand args)
    {
        var (name, description, sku) = args;
        var product = new Product(name, description, sku);
        _repo.Register(product);
        return product.Id;
    }
}