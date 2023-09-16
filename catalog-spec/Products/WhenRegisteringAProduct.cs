using FluentAssertions;
using static Catalog.Spec.Kernel.ObjectProvider;

namespace Catalog.Spec.Products;

public class WhenRegisteringAProduct
{
    [Fact]
    public void ThenDescriptionIsSet()
    {
        RegisteredProduct.Description.Should().Be(_description);
    }

    [Fact]
    public void ThenIdIsSet()
    {
        RegisteredProduct.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void ThenNameIsSet()
    {
        RegisteredProduct.Name.Should().Be(_name);
    }

    [Fact]
    public void ThenProductIsStaged()
    {
        RegisteredProduct.Status.Should().Be(ProductStatus.Staged);
    }

    [Fact]
    public void ThenSkuIsSet()
    {
        RegisteredProduct.Sku.Should().Be(_sku);
    }
}