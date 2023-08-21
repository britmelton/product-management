using Api.DataContracts;
using Api.Spec.Setup;
using FluentAssertions;
using System.Net.Http.Json;

namespace Api.Spec
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
            await HttpClient.PutAsJsonAsync($"activate/{id}", new object());
            await HttpClient.PutAsJsonAsync($"deactivate/{id}", new object());

            var product = await HttpClient.GetFromJsonAsync<ProductDetails>($"catalog/{id}");

            product.IsActive.Should().BeFalse();
            product.IsStaged.Should().BeFalse();
        }
    }
}