﻿using Api.DataContracts;
using Api.Spec.Setup;
using System.Net.Http.Json;
using FluentAssertions;
using Warehouse;

namespace Api.Spec
{
    public class WhenReceivingProducts : WebApiFixture
    {
        public WhenReceivingProducts(IntegrationTestingFactory<Program> factory)
            : base(factory, "product") { }

        [Fact]
        public async void ThenProductQuantityIsUpdated()
        {
            var sku = "abg123";
            var regProduct = new RegisterProduct("product", "description", sku);
            var newProduct = await HttpClient.PostAsJsonAsync("", regProduct);
            var id = newProduct.Headers.Location.AbsolutePath.Split('/')[^1];

            var qty = 20;
            var dto = new ReceiveShipProduct(Guid.Parse(id), qty, sku);
            await HttpClient.PutAsJsonAsync($"receive/{sku}", dto);

            var product = await HttpClient.GetFromJsonAsync<ReceiveShipProduct>($"warehouse/{sku}");

            product.Quantity.Should().Be(20);

            var warehouseRepo = Resolve<IWarehouseProductRepository>();
            warehouseRepo.Delete(Guid.Parse(id));
        }
    }
}