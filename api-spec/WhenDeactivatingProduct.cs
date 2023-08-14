using api.DataContracts;
using api_spec.Setup;
using FluentAssertions;
using System.Net.Http.Json;

namespace api_spec
{
    public class WhenDeactivatingProduct : WebApiFixture
    {
        public WhenDeactivatingProduct(IntegrationTestingFactory<Program> factory, string uri = default) 
            : base(factory, "product") { }

        [Fact]
        public async void ThenIsActiveReturnsFalse_AndIsStagedReturnsFalse()
        {
            var dto = new RegisterProduct("product", "description", "abc123");

            var result = await HttpClient.PostAsJsonAsync("", dto);

            var id = result.Headers.Location.AbsolutePath.Split('/')[^1]; 
            
            await HttpClient.PutAsJsonAsync($"{id}/activate", new object());

            await HttpClient.PutAsJsonAsync($"{id}/deactivate", new object());

            var product = await HttpClient.GetFromJsonAsync<ProductDetails>(result.Headers.Location);

            product.IsActive.Should().BeFalse();
            product.IsStaged.Should().BeFalse();
        }
    }
}
