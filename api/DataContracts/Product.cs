namespace Api.DataContracts
{
    public record ProductDetails(
        string Description,
        string Name,
        string Sku,
        bool IsActive,
        bool IsStaged
    )
    {
        public static implicit operator ProductDetails(Catalog.Infrastructure.Read.Product source) =>
            new(source.Description, source.Name, source.Sku, source.IsActive, source.IsStaged);
    }

    public record RegisterProduct(
            string Description,
            string Name,
            string Sku
        );

    public record ProductPrice(
        Guid Id,
        decimal Price,
        string Sku
    )
    {
        public static implicit operator ProductPrice(Sales.Infrastructure.Read.Product source) =>
            new(source.Id, source.Price.Value, source.Sku);
    }
}