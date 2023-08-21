using Sales;

namespace App.Services
{
    public class SalesProductService : ISalesProductService
    {
        private readonly ISalesProductRepository _repo;

        public SalesProductService(ISalesProductRepository repo)
        {
            _repo = repo;
        }
        public void SetPrice(SetPriceCommand args)
        {
            var (id, price, sku) = args;

            var product = _repo.Find(id);
            product.SetPrice(price);

            _repo.Update(product);
        }
    }
}