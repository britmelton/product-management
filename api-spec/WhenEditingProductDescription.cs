using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using Catalog;
using FluentAssertions;

namespace Api.Spec;

public class WhenEditingProductDescription : WebApiFixture
{
    public WhenEditingProductDescription(IntegrationTestingFactory<Program> factory, string uri = default)
        : base(factory, "catalog/products") { }

    [Fact]
    public async void ThenDescriptionIsNewDescription()
    {
        var sku = "abe123";
        var dto = new RegisterProduct("product", "description", sku);

        await HttpClient.PostAsJsonAsync("", dto);

        var editDto = new EditDescriptionDto("this is a description", sku);
        await HttpClient.PutAsJsonAsync($"{sku}/description", editDto);

        var product = await HttpClient.GetFromJsonAsync<ProductDetails>($"{sku}");

        product.Description.Should().Be(editDto.Description);

        var catalogRepo = Resolve<ICatalogProductRepository>();
        catalogRepo.Delete(sku);
    }
}