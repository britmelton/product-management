namespace Api.DataContracts
{
    public record EditDescriptionDto(
        string Description,
        string Sku
    );

    public record EditNameDto(
        string Name,
        string Sku
    );

    public record UpdateProductStatusDto(
        string Sku
    );
}