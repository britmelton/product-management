using catalog;

namespace api.DataContracts
{
    public record ProductDto(
        string Description,
        string Name,
        string Sku,
        bool IsActive,
        bool IsStaged
    )
    {
        public static implicit operator ProductDto(catalog.infrastructure.read.ProductDto source) =>
            new(source.Description, source.Name, source.Sku, source.IsActive, source.IsStaged);
    }

    public record RegisterProductDto(
            string Description,
            string Name,
            string Sku
        );
}
