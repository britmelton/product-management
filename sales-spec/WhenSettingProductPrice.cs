using FluentAssertions;

namespace Sales.Spec
{
    public class WhenSettingProductPrice
    {
        private readonly Product _product;
        private const decimal _price = 26.99m;
        private const string _sku = "abc123";

        public WhenSettingProductPrice()
        {
            _product = new(_price, _sku);
        }

        [Fact]
        public void ThenPriceIsSet()
        {
            _product.Price.Should().Be(_price);
        }

        [Fact]
        public void ThenSkuIsSet()
        {
            _product.Sku.Should().Be(_sku);
        }
    }
}
