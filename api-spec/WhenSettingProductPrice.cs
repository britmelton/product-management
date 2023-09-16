using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using FluentAssertions;
using FluentAssertions.Execution;
using Sales;

namespace Api.Spec;

public class WhenSettingProductPrice : WebApiFixture
{
    private const string _salesProducts = "sales/products";
    public WhenSettingProductPrice(IntegrationTestingFactory<Program> factory)
        : base(factory, "") { }

    [Fact]
    public async void ThenPriceIsSet()
    {
        var price = 28.25m;
        var sku = "abi123";

        var createProduct = new RegisterProduct("", "description", sku);

        await HttpClient.PostAsJsonAsync("catalog/products", createProduct);

        var dto = new ProductPrice(price, sku);
        await HttpClient.PutAsJsonAsync($"{_salesProducts}/{sku}/price", dto);

        var product = await HttpClient.GetFromJsonAsync<ProductPrice>($"{_salesProducts}/{sku}");

        var scope = new AssertionScope();
        product.Should().NotBeNull();
        product.Price.Should().Be(price);

        var salesRepo = Resolve<ISalesProductRepository>();
        salesRepo.Delete(product.Sku);
    }
}