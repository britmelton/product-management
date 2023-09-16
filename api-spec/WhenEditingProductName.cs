using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using Catalog;
using FluentAssertions;

namespace Api.Spec;

public class WhenEditingProductName : WebApiFixture
{
    public WhenEditingProductName(IntegrationTestingFactory<Program> factory, string uri = default)
        : base(factory, "catalog/products") { }

    [Fact]
    public async void ThenNameIsNewName()
    {
        var sku = "abf123";
        var dto = new RegisterProduct("product", "description", sku);

        await HttpClient.PostAsJsonAsync("", dto);

        var editDto = new EditNameDto( "newName", sku);
        await HttpClient.PutAsJsonAsync($"{sku}/name", editDto);

        var product = await HttpClient.GetFromJsonAsync<ProductDetails>($"{sku}");

        product.Name.Should().Be(editDto.Name);

        var catalogRepo = Resolve<ICatalogProductRepository>();
        catalogRepo.Delete(sku);
    }
}