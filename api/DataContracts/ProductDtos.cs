namespace api.DataContracts
{
    public record ProductDto(
        string Name,
        string Description,
        string Sku
    );

    public record RegisterProductDto(
        string Name,
        string Description,
        string Sku
    );
}
