namespace App.Services
{
    public record EditDescriptionCommand(
        Guid Id,
        string Description,
        string Sku
    );

    public record EditNameCommand(
        Guid Id,
        string Name,
        string Sku
    );

    public record ReceiveShipCommand(
        Guid Id,
        int Quantity,
        string Sku
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

    public record UpdateProductStatusCommand(
        Guid Id,
        string Sku
    );
}