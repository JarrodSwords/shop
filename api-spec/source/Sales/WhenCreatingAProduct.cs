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
                "Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements.",
                "Lunch Box",
                25,
                "MLC-LB-STD"
            );

            var result = await HttpClient.PostAsJsonAsync("products", lunchBox);

            result.Headers.Location.Should().NotBeNull();

            var returnedProduct = result.Content.ReadFromJsonAsync<ProductDto>().Result;

            var storedProduct = await HttpClient.GetFromJsonAsync<ProductDto>($"products/{returnedProduct.Sku}");

            returnedProduct.Should().Be(storedProduct);
        }

        #endregion
    }
}
