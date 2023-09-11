using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using Catalog;
using FluentAssertions;

namespace Api.Spec
{
    public class WhenActivatingProduct : WebApiFixture
    {
        public WhenActivatingProduct(IntegrationTestingFactory<Program> factory, string uri = default)
            : base(factory, "product") { }

        [Fact]
        public async void ThenIsActiveReturnsTrue_AndIsStagedReturnsFalse()
        {
            var sku = "abc123";
            var dto = new RegisterProduct("product", "description", sku);
            var result = await HttpClient.PostAsJsonAsync("", dto);

            var id = result.Headers.Location.AbsolutePath.Split('/')[^1];
            var updateStatusDto = new UpdateProductStatusDto(Guid.Parse(id), sku);
            await HttpClient.PutAsJsonAsync($"activate/{sku}", updateStatusDto);
            var product = await HttpClient.GetFromJsonAsync<ProductDetails>($"catalog/{sku}");

            product.IsActive.Should().BeTrue();
            product.IsStaged.Should().BeFalse();

            var catalogRepo = Resolve<ICatalogProductRepository>();
            catalogRepo.Delete(Guid.Parse(id));
        }
    }
}