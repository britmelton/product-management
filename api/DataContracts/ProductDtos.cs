namespace api.DataContracts
{
    public record ProductDto(
        string Description,
        string Name,
        string Sku
    );

    public record RegisterProductDto(
        string Description,
        string Name,
        string Sku
    );
}
