using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Shop.Api.Spec
{
    public class IntegrationTestingFactory<T> : WebApplicationFactory<T> where T : class
    {
        #region Protected Interface

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("IntegrationTesting");
        }

        #endregion
    }
}
