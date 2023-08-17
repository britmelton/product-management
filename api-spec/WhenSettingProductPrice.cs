using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using FluentAssertions;

namespace Api.Spec
{
    public class WhenSettingProductPrice : WebApiFixture
    {
        public WhenSettingProductPrice(IntegrationTestingFactory<Program> factory)
            : base(factory, "product") { }

        [Fact]
        public async void ThenProductIsRegistered()
        {
            var pdto = new RegisterProduct("product", "description", "abc123");
            var newProduct = await HttpClient.PostAsJsonAsync("", pdto);
            var id = newProduct.Headers.Location.AbsolutePath.Split('/')[^1];

            var price = 28.25m;
            var dto = new SetProductPrice(Guid.Parse(id), price);
            var result = await HttpClient.PutAsJsonAsync($"{id}/price", dto);

            var product = await HttpClient.GetFromJsonAsync<SetProductPrice>(result.Headers.Location);

            product.Should().NotBeNull();
            product.Price.Should().Be(price);
        }
    }
}
