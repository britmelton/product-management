using FluentAssertions;
using static Catalog.Spec.Kernel.ObjectProvider;

namespace Catalog.Spec.Products;

public class WhenEditingProductName
{
    [Theory]
    [InlineData("thisName")]
    [InlineData("foo")]
    [InlineData("bar")]
    public void ThenNameIsChanged(string newName)
    {
        _Product.EditName(newName);
        _Product.Name.Should().Be(newName);
    }
}