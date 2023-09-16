namespace Catalog.Spec.Kernel
{
    public static class ObjectProvider
    { 
        internal static readonly string _description = "product description";
        internal static readonly string _name = "product name";
        internal static readonly Sku _sku = new("abc123");

        internal static readonly Product _Product = new(_description, _name, _sku);

        internal static readonly Product RegisteredProduct = new(_description, _name, _sku);
    }
}
