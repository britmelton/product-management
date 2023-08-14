using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Api.Spec.Setup
{
    public class IntegrationTestingFactory<T> : WebApplicationFactory<T> where T : class
    { 
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Integration");
        }
    }
}