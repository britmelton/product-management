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
            var (id, qty, sku) = args;

            var product = _repo.Find(id);
            product.Receive(qty);

            _repo.Update(product);
        }

        public void Ship(ReceiveShipCommand args)
        {
            var (id, qty, sku) = args;

            var product = _repo.Find(id);
            product.Ship(qty);

            _repo.Update(product);
        }
    }
}
