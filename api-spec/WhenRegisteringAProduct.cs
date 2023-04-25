using api.DataContracts;
using api_spec.Setup;
using System.Net.Http.Json;
using FluentAssertions;

namespace api_spec
{
    public class WhenRegisteringAProduct : WebApiFixture
    {
        public WhenRegisteringAProduct(IntegrationTestingFactory<Program> factory)
            : base(factory, "product") { }

        [Fact]
        public async void ThenProductIsRegistered()
        {
            var dto = new RegisterProductDto("product", "description", "abc123");
            var result = await HttpClient.PostAsJsonAsync("", dto);

            var product = await HttpClient.GetFromJsonAsync<ProductDto>(result.Headers.Location);
            product.Should().NotBeNull();
        }
    }
}
