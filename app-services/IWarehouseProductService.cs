namespace App.Services
{
    public interface IWarehouseProductService
    {
        public void Receive(ReceiveShipCommand args);
        public void Ship(ReceiveShipCommand args);
    }
}
