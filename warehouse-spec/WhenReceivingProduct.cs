using FluentAssertions;

namespace Warehouse.Spec
{
    public class WhenReceivingProduct
    {
        private readonly string _description = "product description";
        private readonly string _name = "product name";
        private readonly int _quantity = 0;
        private readonly string _sku = "abc123";

        [Fact]
        public void ThenQuantityIsUpdated()
        {
            var product = new Product(_description, _name, _quantity, _sku);

            product.Receive(20);

            product.Quantity.Should().Be(20);
        }

        [Fact]
        public void WithAdditionalQuantity_ThenQuantityIsUpdated()
        {
            var product = new Product(_description, _name, _quantity, _sku);

            product.Receive(20);
            product.Receive(20);

            product.Quantity.Should().Be(40);
        }
    }
}