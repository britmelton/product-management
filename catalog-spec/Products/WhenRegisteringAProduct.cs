using FluentAssertions;

namespace Catalog.Spec.Products
{
    public class WhenRegisteringAProduct
    {
        private readonly Product _product;
        private readonly string _description = "product description";
        private readonly string _name = "product name";
        private readonly Sku _sku = new("abc123");

        public WhenRegisteringAProduct()
        {
            _product = new(_description, _name, _sku);
        }

        [Fact]
        public void ThenDescriptionIsSet()
        {
            _product.Description.Should().Be(_description);
        }

        [Fact]
        public void ThenProductIsStaged()
        {
            _product.Status.Should().Be(ProductStatus.Staged);
        }

        [Fact]
        public void ThenIdIsSet()
        {
            _product.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void ThenNameIsSet()
        {
            _product.Name.Should().Be(_name);
        }

        [Fact]
        public void ThenSkuIsSet()
        {
            _product.Sku.Should().Be(_sku);
        }
    }
}