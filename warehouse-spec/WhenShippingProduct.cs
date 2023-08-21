using FluentAssertions;

namespace Warehouse.Spec
{
    public class WhenShippingProduct
    {
        private readonly string _description = "product description";
        private readonly string _name = "product name";
        private readonly int _quantity = 34;
        private readonly string _sku = "abc123";

        [Fact]
        public void ThenProductQuantityIsUpdated()
        {
            var product = new Product(_description, _name, _quantity, _sku);

            product.Receive(50);
            product.Ship(50);

            product.Quantity.Should().Be(0);
        }

        [Fact]
        public void WhenNotShippingTotal_ThenProductQuantityIsUpdated()
        {
            var product = new Product(_description, _name, _quantity, _sku);

            product.Receive(50);
            product.Ship(50);

            product.Quantity.Should().Be(34);
        }
    }
}
