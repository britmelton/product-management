using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using FluentAssertions;
using Warehouse;

namespace Api.Spec;

public class WhenShippingProducts : WebApiFixture
{
    private const string _warehouseProducts = "warehouse/products";
    public WhenShippingProducts(IntegrationTestingFactory<Program> factory)
        : base(factory, "") { }

    [Fact]
    public async void ThenProductQuantityIsUpdated()
    {
        var qty = 20;
        var sku = "abj123";

        var regProduct = new RegisterProduct("description", "name", sku);

        await HttpClient.PostAsJsonAsync("catalog/products", regProduct);

        var dto = new ReceiveShipProduct(qty, sku);
        await HttpClient.PutAsJsonAsync($"{_warehouseProducts}/{sku}/receive", dto);
        await HttpClient.PutAsJsonAsync($"{_warehouseProducts}/{sku}/ship", dto);

        var product = await HttpClient.GetFromJsonAsync<ReceiveShipProduct>($"{_warehouseProducts}/{sku}");

        product.Quantity.Should().Be(0);

        var warehouseRepo = Resolve<IWarehouseProductRepository>();
        warehouseRepo.Delete(product.Sku);
    }
}