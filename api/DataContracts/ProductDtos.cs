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
        public static implicit operator ProductDto(Product source) =>
            new(source.Description, source.Name, source.Sku, source.Status.HasFlag(ProductStatus.Activated), source.Status.HasFlag(ProductStatus.Staged));
    }

    public record RegisterProductDto(
            string Description,
            string Name,
            string Sku
        );
}
