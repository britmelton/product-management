using catalog;
using FluentAssertions;

namespace catalog_spec.Products
{
    public class WhenActivatingProduct
    {
        private readonly Product _product;
        private readonly string _description = "product description";
        private readonly string _name = "product name";
        private readonly Sku _sku = new("abc123");

        public WhenActivatingProduct()
        {
            _product = new(_description, _name, _sku);
        }
        [Fact]
        public void ThenProductIsActivated()
        {
            _product.Activate();
            _product.Status.Should().Be(ProductStatus.Activated);
        }
    }
}