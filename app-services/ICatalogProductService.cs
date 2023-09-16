namespace App.Services
{
    public interface ICatalogProductService
    {
        public void Activate(UpdateProductStatusCommand args);
        public void Deactivate(UpdateProductStatusCommand args);
        public void EditDescription(EditDescriptionCommand args);
        public void EditName(EditNameCommand args);
        public void Register(RegisterProductCommand args);
    }
}