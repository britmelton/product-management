﻿using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using FluentAssertions;
using Sales;

namespace Api.Spec
{
    public class WhenSettingProductPrice : WebApiFixture
    {
        public WhenSettingProductPrice(IntegrationTestingFactory<Program> factory)
            : base(factory, "product") { }

        [Fact]
        public async void ThenPriceIsSet()
        {
            var sku = "abi123";
            var createProduct = new RegisterProduct("product", "description", sku);
            var newProduct = await HttpClient.PostAsJsonAsync("", createProduct);
            var id = newProduct.Headers.Location.AbsolutePath.Split('/')[^1];

            var price = 28.25m;
            var dto = new ProductPrice(Guid.Parse(id), price, sku);
            await HttpClient.PutAsJsonAsync($"price/{sku}", dto);

            var product = await HttpClient.GetFromJsonAsync<ProductPrice>($"sales/{sku}");

            product.Should().NotBeNull();
            product.Price.Should().Be(price);

            var salesRepo = Resolve<ISalesProductRepository>();
            salesRepo.Delete(product.Sku);
        }
    }
}