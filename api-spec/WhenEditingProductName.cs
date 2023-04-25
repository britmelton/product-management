using System.Net.Http.Json;
using api.DataContracts;
using api_spec.Setup;
using FluentAssertions;

namespace api_spec
{
    public class WhenEditingProductName : WebApiFixture
    {
        public WhenEditingProductName(IntegrationTestingFactory<Program> factory, string uri = default)
            : base(factory, "product") { }

        [Fact]
        public async void ThenNameIsNewName()
        {
            var dto = new RegisterProductDto("product", "description", "abc123");

            var result = await HttpClient.PostAsJsonAsync("", dto);

            var id = result.Headers.Location.AbsolutePath.Split('/')[^1];

            var editDto = new EditNameDto(Guid.Parse(id), "newName");

            await HttpClient.PutAsJsonAsync($"{id}/name", editDto);

            var product = await HttpClient.GetFromJsonAsync<ProductDto>(result.Headers.Location);

            product.Name.Should().Be(editDto.Name);
        }
    }
}
