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
            var sku = "abd123";
            var dto = new RegisterProduct("product", "description", sku);
            var result = await HttpClient.PostAsJsonAsync("", dto);

            var id = result.Headers.Location.AbsolutePath.Split('/')[^1];
            var updateStatusDto = new UpdateProductStatusDto(Guid.Parse(id), sku);
            await HttpClient.PutAsJsonAsync($"activate/{sku}", updateStatusDto);
            await HttpClient.PutAsJsonAsync($"deactivate/{sku}", updateStatusDto);

            var product = await HttpClient.GetFromJsonAsync<ProductDetails>($"catalog/{sku}");

            product.IsActive.Should().BeFalse();
            product.IsStaged.Should().BeFalse();
        }
    }
}