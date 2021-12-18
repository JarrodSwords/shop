using System.Threading.Tasks;
using Xunit;

namespace Shop.Api.Spec
{
    public class HealthCheckSpec : WebApiFixture
    {
        #region Core

        public HealthCheckSpec(TestWebApplicationFactory<Startup> factory)
            : base(factory, "healthcheck")
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async Task HealthCheck_ReturnsOk()
        {
            var response = await HttpClient.GetAsync("");

            response.EnsureSuccessStatusCode();
        }

        #endregion
    }
}
