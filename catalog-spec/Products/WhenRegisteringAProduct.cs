using catalog;
using FluentAssertions;

namespace catalog_spec.Products
{
    public class WhenRegisteringAProduct
    {
        private readonly Product _product;
        private readonly string _name = "product name";

        public WhenRegisteringAProduct()
        {
            _product = new Product(_name);
        }

        [Fact]
        public void ThenNameIsSet()
        {
            _product.Name.Should().Be(_name);
        }
    }
}
