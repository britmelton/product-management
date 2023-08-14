namespace api.DataContracts
{
    public record ProductDetails(
        string Description,
        string Name,
        string Sku,
        bool IsActive,
        bool IsStaged
    )
    {
        public static implicit operator ProductDetails(catalog.infrastructure.read.Product source) =>
            new(source.Description, source.Name, source.Sku, source.IsActive, source.IsStaged);
    }

    public record RegisterProduct(
            string Description,
            string Name,
            string Sku
        );
}