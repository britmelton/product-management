using FluentAssertions;
using static Catalog.Spec.Kernel.ObjectProvider;

namespace Catalog.Spec.Products;

public class WhenEditingProductDescription
{
    [Theory]
    [InlineData("new description")]
    [InlineData("this description")]
    [InlineData("that description")]
    public void ThenNameIsChanged(string newDescription)
    {
        _Product.EditDescription(newDescription);
        _Product.Description.Should().Be(newDescription);
    }
}