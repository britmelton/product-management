namespace app_services;
public interface IProductService
{
    public void Activate(Guid id);
    public void Deactivate(Guid id);
    public void EditDescription(EditDescriptionCommand args);
    public void EditName(EditNameCommand args);
    public Guid Register(RegisterProductCommand args);
}
