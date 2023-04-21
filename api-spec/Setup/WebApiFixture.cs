using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace api_spec.Setup
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
