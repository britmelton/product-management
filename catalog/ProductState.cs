namespace Catalog
{
    [Flags]
    public enum ProductStatus
    {
        Activated = 1 << 0,
        Staged = 1 << 1,
        Deactivated = 1 << 2,
    }
}