using FluentAssertions;

namespace Catalog.Spec.Products
{
    public class WhenDeactivatingProduct
    {
        private readonly Product _product;
        private readonly string _description = "product description";
        private readonly string _name = "product name";
        private readonly Sku _sku = new("abc123");

        public WhenDeactivatingProduct()
        {
            _product = new(_description, _name, _sku);
        }

        [Fact]
        public void ThenProductIsDeactivated()
        {
            _product.Activate();
            _product.Deactivate();
            _product.Status.Should().Be(ProductStatus.Deactivated);
        }
    }
}