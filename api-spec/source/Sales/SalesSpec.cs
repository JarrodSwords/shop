using Xunit;

namespace Shop.Api.Spec.Sales
{
    public class SalesSpec : WebApiFixture
    {
        #region Core

        public SalesSpec(
            TestWebApplicationFactory<Startup> factory,
            string uri = default
        ) : base(factory, "api/sales")
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async void FetchOrders_ReturnsOk()
        {
            var response = await HttpClient.GetAsync("orders");

            response.EnsureSuccessStatusCode();
        }

        #endregion
    }
}
