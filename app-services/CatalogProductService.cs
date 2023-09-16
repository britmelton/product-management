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
            var sku = args.Sku;
            var product = _repo.Find(sku);

            product.Activate();

            _repo.Update(product);
        }

        public void Deactivate(UpdateProductStatusCommand args)
        {
            var sku = args.Sku;
            var product = _repo.Find(sku);

            product.Deactivate();

            _repo.Update(product);
        }

        public void EditDescription(EditDescriptionCommand args)
        {
            var (description, sku) = args;

            var product = _repo.Find(sku);
            product.EditDescription(description);

            _repo.Update(product);
        }

        public void EditName(EditNameCommand args)
        {
            var (name, sku) = args;

            var product = _repo.Find(sku);
            product.EditName(name);

            _repo.Update(product);
        }

        public void Register(RegisterProductCommand args)
        {
            var (name, description, sku) = args;
            var product = new Product(name, description, sku);
            _repo.Register(product);
        }
    }
}