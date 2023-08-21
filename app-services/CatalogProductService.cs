using Catalog;

namespace App.Services
{
    public class CatalogProductService : ICatalogProductService
    {
        private readonly ICatalogProductRepository _repo;

        public CatalogProductService(ICatalogProductRepository repo)
        {
            _repo = repo;
        }

        public void Activate(UpdateProductStatusCommand args)
        {
            var (id, sku) = args;
            var product = _repo.Find(id);

            product.Activate();

            _repo.Update(product);
        }

        public void Deactivate(UpdateProductStatusCommand args)
        {
            var (id, sku) = args;
            var product = _repo.Find(id);

            product.Deactivate();

            _repo.Update(product);
        }

        public void EditDescription(EditDescriptionCommand args)
        {
            var (id, description, sku) = args;

            var product = _repo.Find(id);
            product.EditDescription(description);

            _repo.Update(product);
        }

        public void EditName(EditNameCommand args)
        {
            var (id, name, sku) = args;

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
}