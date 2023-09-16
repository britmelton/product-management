using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using Catalog;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Api.Spec;

public class WhenActivatingProduct : WebApiFixture
{
    public WhenActivatingProduct(IntegrationTestingFactory<Program> factory, string uri = default)
        : base(factory, "catalog/products") { }

    [Fact]
    public async void ThenIsActiveReturnsTrue_AndIsStagedReturnsFalse()
    {
        var sku = "abc123";
        var dto = new RegisterProduct("product", "description", sku);

        await HttpClient.PostAsJsonAsync("", dto);

        var updateStatusDto = new UpdateProductStatusDto(sku);
        await HttpClient.PutAsJsonAsync($"{sku}/activate", updateStatusDto);

        var product = await HttpClient.GetFromJsonAsync<ProductDetails>($"{sku}");

        var scope = new AssertionScope();
        product.IsActive.Should().BeTrue();
        product.IsStaged.Should().BeFalse();

        var catalogRepo = Resolve<ICatalogProductRepository>();
        catalogRepo.Delete(sku);
    }
}