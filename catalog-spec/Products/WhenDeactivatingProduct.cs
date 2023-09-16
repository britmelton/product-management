using FluentAssertions;
using static Catalog.Spec.Kernel.ObjectProvider;

namespace Catalog.Spec.Products;
public class WhenDeactivatingProduct
{
    [Fact]
    public void ThenProductIsDeactivated()
    {
        _Product.Activate();
        _Product.Deactivate();

        _Product.Status.Should().Be(ProductStatus.Deactivated);
    }
}