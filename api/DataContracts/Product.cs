namespace Api.DataContracts
{
    public record ProductDetails(
        Guid Id,
        string Description,
        string Name,
        string Sku,
        bool IsActive,
        bool IsStaged
    )
    {
        public static implicit operator ProductDetails(Catalog.Infrastructure.Read.Product source) =>
            new(source.Id,source.Description, source.Name, source.Sku, source.IsActive, source.IsStaged);
    }

    public record RegisterProduct(
        string Description,
        string Name,
        string Sku
    );

    public record ProductPrice(
        decimal Price,
        string Sku
    )
    {
        public static implicit operator ProductPrice(Sales.Infrastructure.Read.Product source) =>
            new(source.Price.Value, source.Sku);
    }

    public record ReceiveShipProduct(
        int Quantity,
        string Sku
    )
    {

        public static implicit operator ReceiveShipProduct(Warehouse.Infrastructure.Read.Product source) =>
            new(source.Quantity,source.Sku);
    }
}