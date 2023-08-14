namespace Catalog.Infrastructure.Read
{
    public record Product
    {
        public string Description { get; init; }
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Sku { get; init; }
        public bool IsActive { get; init; }
        public bool IsStaged { get; init; }
    }
}