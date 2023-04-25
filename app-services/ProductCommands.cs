namespace app_services
{
    public record EditDescriptionCommand(
        Guid Id,
        string Description
    );

    public record EditNameCommand(
        Guid Id,
        string Name
    );

    public record RegisterProductCommand(
        string Name,
        string Description,
        string Sku
    );
}
