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
        public void SetPrice(ProductPriceCommand args)
        {
            var (id, price) = args;

            var product = _repo.Find(id);
            product.Price = price;

            _repo.Update(product);
        }
    }
}