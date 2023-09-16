using Api.DataContracts;
using Api.Spec.Setup;
using System.Net.Http.Json;
using FluentAssertions;
using Warehouse;

namespace Api.Spec;

public class WhenReceivingProducts : WebApiFixture
{
    private const string _warehouseProducts = "warehouse/products";
    public WhenReceivingProducts(IntegrationTestingFactory<Program> factory)
        : base(factory, "") { }

    [Fact]
    public async void ThenProductQuantityIsUpdated()
    {
        var qty = 20;
        var sku = "abg123";

        var regProduct = new RegisterProduct("product", "description", sku);
        await HttpClient.PostAsJsonAsync("catalog/products", regProduct);

        var dto = new ReceiveShipProduct(qty, sku);
        await HttpClient.PutAsJsonAsync($"{_warehouseProducts}/{sku}/receive", dto);

        var product = await HttpClient.GetFromJsonAsync<ReceiveShipProduct>($"{_warehouseProducts}/{sku}");

        product.Quantity.Should().Be(20);

        var warehouseRepo = Resolve<IWarehouseProductRepository>();
        warehouseRepo.Delete(sku);
    }
}