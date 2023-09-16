using FluentAssertions;
using static Catalog.Spec.Kernel.ObjectProvider;

namespace Catalog.Spec.Products;

public class WhenActivatingProduct
{
    [Fact]
    public void ThenProductIsActivated()
    {
        _Product.Activate();
        _Product.Status.Should().Be(ProductStatus.Activated);
    }

    [Fact]
    public void ThenProductIsNotStaged()
    {
        _Product.Activate();
        _Product.Status.Should().NotBe(ProductStatus.Staged);
    }
}