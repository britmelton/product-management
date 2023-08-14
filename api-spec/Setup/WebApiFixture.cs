using Microsoft.AspNetCore.Mvc.Testing;

namespace Api.Spec.Setup
{
    public abstract class WebApiFixture : IClassFixture<IntegrationTestingFactory<Program>>
    {
        protected WebApiFixture(
            WebApplicationFactory<Program> factory,
            string uri = default
            )
        {
            if (uri != default)
                factory.ClientOptions.BaseAddress = new Uri($"http://localhost/api/{uri}/");
            HttpClient = factory.CreateClient();
        }

        protected HttpClient HttpClient { get; }
    }
}