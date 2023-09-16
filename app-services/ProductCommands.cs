namespace App.Services
{
    public record EditDescriptionCommand(
        string Description,
        string Sku
    );

    public record EditNameCommand(
        string Name,
        string Sku
    );

    public record ReceiveShipCommand(
        int Quantity,
        string Sku
    );

    public record RegisterProductCommand(
        string Description,
        string Name,
        string Sku
    );

    public record SetPriceCommand(
        decimal Price,
        string Sku
    );

    public record UpdateProductStatusCommand(
        string Sku
    );
}