using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using Catalog;
using FluentAssertions;

namespace Api.Spec
{
    public class WhenEditingProductDescription : WebApiFixture
    {
        public WhenEditingProductDescription(IntegrationTestingFactory<Program> factory, string uri = default)
            : base(factory, "product") { }

        [Fact]
        public async void ThenDescriptionIsNewDescription()
        {
            var sku = "abe123";
            var dto = new RegisterProduct("product", "description", sku);
            var result = await HttpClient.PostAsJsonAsync("", dto);

            var id = result.Headers.Location.AbsolutePath.Split('/')[^1];
            var editDto = new EditDescriptionDto(Guid.Parse(id), "this is a description", sku);

            await HttpClient.PutAsJsonAsync($"description/{sku}", editDto);
            var product = await HttpClient.GetFromJsonAsync<ProductDetails>($"catalog/{sku}");

            product.Description.Should().Be(editDto.Description);

            var catalogRepo = Resolve<ICatalogProductRepository>();
            catalogRepo.Delete(Guid.Parse(id));
        }
    }
}