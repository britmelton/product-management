namespace app_services
{
    public record RegisterProductCommand(
        string Name,
        string Description,
        string Sku
    );

    public record EditNameCommand(
        Guid Id,
        string Name
    );
}
