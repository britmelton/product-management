using Api.DataContracts;
using Api.Spec.Setup;
using Catalog;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Net.Http.Json;

namespace Api.Spec;

public class WhenDeactivatingProduct : WebApiFixture
{
    public WhenDeactivatingProduct(IntegrationTestingFactory<Program> factory, string uri = default)
        : base(factory, "catalog/products") { }

    [Fact]
    public async void ThenIsActiveReturnsFalse_AndIsStagedReturnsFalse()
    {
        var sku = "abd123";
        var dto = new RegisterProduct("product", "description", sku);

        await HttpClient.PostAsJsonAsync("", dto);

        var updateStatusDto = new UpdateProductStatusDto(sku);
        await HttpClient.PutAsJsonAsync($"{sku}/activate", updateStatusDto);
        await HttpClient.PutAsJsonAsync($"{sku}/deactivate", updateStatusDto);

        var product = await HttpClient.GetFromJsonAsync<ProductDetails>($"{sku}");

        var scope = new AssertionScope();
        product.IsActive.Should().BeFalse();
        product.IsStaged.Should().BeFalse();

        var catalogRepo = Resolve<ICatalogProductRepository>();
        catalogRepo.Delete(sku);
    }
}