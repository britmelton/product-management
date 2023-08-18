using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using FluentAssertions;

namespace Api.Spec
{
    public class WhenEditingProductName : WebApiFixture
    {
        public WhenEditingProductName(IntegrationTestingFactory<Program> factory, string uri = default)
            : base(factory, "product") { }

        [Fact]
        public async void ThenNameIsNewName()
        {
            var dto = new RegisterProduct("product", "description", "abc123");
            var result = await HttpClient.PostAsJsonAsync("", dto);

            var id = result.Headers.Location.AbsolutePath.Split('/')[^1];
            var editDto = new EditNameDto(Guid.Parse(id), "newName");

            await HttpClient.PutAsJsonAsync($"{id}/name", editDto);
            var product = await HttpClient.GetFromJsonAsync<ProductDetails>($"catalog/{id}");

            product.Name.Should().Be(editDto.Name);
        }
    }
}