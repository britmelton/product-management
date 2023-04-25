using catalog;
using FluentAssertions;

namespace catalog_spec.Products
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
        public void ThenIsActiveReturnsFalse()
        {
            _product.Deactivate();

            _product.IsActive.Should().BeFalse();
        }

        [Fact]
        public void ThenIsStagedReturnsFalse()
        {
            _product.Deactivate();

            _product.IsStaged.Should().BeFalse();
        }
    }
}
