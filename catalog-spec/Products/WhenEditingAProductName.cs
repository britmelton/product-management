using catalog;
using FluentAssertions;

namespace catalog_spec.Products
{
    public class WhenEditingAProductName
    {
        private readonly Product _product;
        private readonly Sku _sku = new("abc123");
        private readonly string _name = "product";
        private readonly string _description = "product description";

        public WhenEditingAProductName()
        {
            _product = new(_name, _description, _sku);
        }

        [Theory]
        [InlineData("thisName")]
        [InlineData("foo")]
        [InlineData("bar")]
        public void ThenNameIsChanged(string newName)
        {
            _product.EditName(newName);
            _product.Name.Should().Be(newName);
        }
    }
}
