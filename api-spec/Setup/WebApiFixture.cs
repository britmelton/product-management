using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Spec.Setup
{
    [Collection("storage")]
    public abstract class WebApiFixture : IClassFixture<IntegrationTestingFactory<Program>>
    {
        private static IServiceScope _scope;

        protected WebApiFixture(
            WebApplicationFactory<Program> factory,
            string uri = default
            )
        {
            _scope = factory.Services.CreateScope();

            if (uri != default)
                factory.ClientOptions.BaseAddress = new Uri($"http://localhost/api/{uri}/");
            HttpClient = factory.CreateClient();
        }

        protected HttpClient HttpClient { get; }

        public static T Resolve<T>() where T : notnull => _scope.ServiceProvider.GetRequiredService<T>();
    }
}