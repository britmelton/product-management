namespace Api.DataContracts
{
    public record EditDescriptionDto(
        Guid Id,
        string Description,
        string Sku
    );

    public record EditNameDto(
        Guid Id,
        string Name,
        string Sku
    );

    public record UpdateProductStatusDto(
        Guid Id,
        string Sku
    );
}