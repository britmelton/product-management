﻿namespace app_services;
public interface IProductService
{
    public void EditName(EditNameCommand args);
    public Guid Register(RegisterProductCommand args);
}
