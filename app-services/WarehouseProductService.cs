using Warehouse;

namespace App.Services
{
    public class WarehouseProductService : IWarehouseProductService
    {
        private readonly IWarehouseProductRepository _repo;

        public WarehouseProductService(IWarehouseProductRepository repo)
        {
            _repo = repo;
        }

        public void Receive(ReceiveShipCommand args)
        {
            var (qty, sku) = args;

            var product = _repo.Find(sku);
            product.Receive(qty);

            _repo.Update(product);
        }

        public void Ship(ReceiveShipCommand args)
        {
            var (qty, sku) = args;

            var product = _repo.Find(sku);
            product.Ship(qty);

            _repo.Update(product);
        }
    }
}
