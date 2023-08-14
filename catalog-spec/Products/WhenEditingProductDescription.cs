using FluentAssertions;

namespace Catalog.Spec.Products
{
    public class WhenEditingProductDescription
    {
        private readonly Product _product;
        private readonly Sku _sku = new("abc123");
        private readonly string _name = "product";
        private readonly string _description = "product description";

        public WhenEditingProductDescription()
        {
            _product = new(_name, _description, _sku);
        }

        [Theory]
        [InlineData("new description")]
        [InlineData("this description")]
        [InlineData("that description")]
        public void ThenNameIsChanged(string newDescription)
        {
            _product.EditDescription(newDescription);
            _product.Description.Should().Be(newDescription);
        }
    }
}