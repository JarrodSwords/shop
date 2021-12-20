using System.Net.Http.Json;
using FluentAssertions;
using Shop.Sales.Services;
using Xunit;

namespace Shop.Api.Spec.Sales
{
    [Collection("storage")]
    public class WhenCreatingAProduct : WebApiFixture
    {
        #region Core

        public WhenCreatingAProduct(IntegrationTestingFactory<Startup> factory) : base(
            factory,
            "api/sales"
        )
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async void ThenTheProductIsRetrievable()
        {
            var lunchBox = new RegisterProduct(
                "Lunch Box serves one and comes with one meat, one cheese, and accoutrements.",
                "Lunch Box",
                25,
                "MLC-LB-STD"
            );

            var sku = await HttpClient.PostAsJsonAsync("products", lunchBox)
                .Result.Content.ReadFromJsonAsync<string>();

            var product = await HttpClient.GetFromJsonAsync<ProductDto>($"products/{sku}");

            product.Should().NotBeNull();
        }

        #endregion
    }
}
