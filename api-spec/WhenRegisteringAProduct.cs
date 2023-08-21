using Api.DataContracts;
using Api.Spec.Setup;
using System.Net.Http.Json;
using FluentAssertions;

namespace Api.Spec
{
    public class WhenRegisteringAProduct : WebApiFixture
    {
        public WhenRegisteringAProduct(IntegrationTestingFactory<Program> factory)
            : base(factory, "product") { }

        [Fact]
        public async void ThenProductIsRegistered()
        {
            var dto = new RegisterProduct("description", "name", "abh123");
            var result = await HttpClient.PostAsJsonAsync("", dto);

            var product = await HttpClient.GetFromJsonAsync<ProductDetails>(result.Headers.Location);

            product.Should().NotBeNull();
            product.IsStaged.Should().BeTrue();
            product.IsActive.Should().BeFalse();
        }
    }
}