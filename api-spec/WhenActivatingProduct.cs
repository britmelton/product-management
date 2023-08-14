using System.Net.Http.Json;
using api.DataContracts;
using api_spec.Setup;
using FluentAssertions;

namespace api_spec
{
    public class WhenActivatingProduct : WebApiFixture
    {
        public WhenActivatingProduct(IntegrationTestingFactory<Program> factory, string uri = default)
            : base(factory, "product") { }

        [Fact]
        public async void ThenIsActiveReturnsTrue_AndIsStagedReturnsFalse()
        {
            var dto = new RegisterProduct("product", "description", "abc123");

            var result = await HttpClient.PostAsJsonAsync("", dto);

            var id = result.Headers.Location.AbsolutePath.Split('/')[^1];

            await HttpClient.PutAsJsonAsync($"{id}/activate", new object());

            var product = await HttpClient.GetFromJsonAsync<ProductDetails>(result.Headers.Location);

            product.IsActive.Should().BeTrue();
            product.IsStaged.Should().BeFalse();
        }
    }
}
