﻿using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using FluentAssertions;

namespace Api.Spec
{
    public class WhenShippingProducts : WebApiFixture
    {
        public WhenShippingProducts(IntegrationTestingFactory<Program> factory)
            : base(factory, "product") { }

        [Fact]
        public async void ThenProductQuantityIsUpdated()
        {
            var sku = "abc123";
            var regProduct = new RegisterProduct("product", "description", sku);
            var newProduct = await HttpClient.PostAsJsonAsync("", regProduct);
            var id = newProduct.Headers.Location.AbsolutePath.Split('/')[^1];

            var qty = 20;
            var dto = new ReceiveShipProduct(Guid.Parse(id), qty);
            await HttpClient.PutAsJsonAsync($"receive/{id}", dto);
            await HttpClient.PutAsJsonAsync($"ship/{id}", dto);

            var product = await HttpClient.GetFromJsonAsync<ReceiveShipProduct>($"warehouse/{id}");

            product.Quantity.Should().Be(0);
        }
    }
}