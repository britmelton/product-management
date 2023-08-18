namespace App.Services
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
        string Description,
        string Name,
        string Sku
    );

    public record SetPriceCommand(
        Guid Id,
        decimal Price,
        string Sku
    );
}