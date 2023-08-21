using FluentAssertions;

namespace Sales.Spec
{
    public class WhenAdjustingPrice
    {
        private readonly Product _product;
        private const decimal _price = 26.99m;
        private const string _sku = "abc123";

        public WhenAdjustingPrice()
        {
            _product = new(_price, _sku);
        }

        [Fact]
        public void ThenPriceShouldBeNewPrice()
        {
            var newPrice = 23.98m;
            _product.SetPrice(newPrice);

            _product.Price.Should().Be(newPrice);
        }
    }
}