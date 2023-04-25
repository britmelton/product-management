using System.Net.Http.Json;
using api.DataContracts;
using api_spec.Setup;
using FluentAssertions;

namespace api_spec
{
    public class WhenEditingProductDescription : WebApiFixture
    {
        public WhenEditingProductDescription(IntegrationTestingFactory<Program> factory, string uri = default)
            : base(factory, "product") { }

        [Fact]
        public async void ThenDescriptionIsNewDescription()
        {
            var dto = new RegisterProductDto("product", "description", "abc123");

            var result = await HttpClient.PostAsJsonAsync("", dto);

            var id = result.Headers.Location.AbsolutePath.Split('/')[^1];

            var editDto = new EditDescriptionDto(Guid.Parse(id), "this is a description");

            await HttpClient.PutAsJsonAsync($"{id}/description", editDto);

            var product = await HttpClient.GetFromJsonAsync<ProductDto>(result.Headers.Location);

            product.Description.Should().Be(editDto.Description);

        }
    }
}
