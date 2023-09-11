using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using Catalog;
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
            var sku = "abf123";
            var dto = new RegisterProduct("product", "description", sku);
            var result = await HttpClient.PostAsJsonAsync("", dto);

            var id = result.Headers.Location.AbsolutePath.Split('/')[^1];
            var editDto = new EditNameDto(Guid.Parse(id), "newName", sku);

            await HttpClient.PutAsJsonAsync($"name/{sku}", editDto);
            var product = await HttpClient.GetFromJsonAsync<ProductDetails>($"catalog/{sku}");

            product.Name.Should().Be(editDto.Name);

            var catalogRepo = Resolve<ICatalogProductRepository>();
            catalogRepo.Delete(Guid.Parse(id));
        }
    }
}