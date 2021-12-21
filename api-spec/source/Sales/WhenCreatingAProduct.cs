using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Shop.Sales.Services;
using Xunit;

namespace Shop.Api.Spec.Sales
{
    [Collection("storage")]
    public class WhenCreatingAProduct : WebApiFixture, IAsyncLifetime
    {
        #region Core

        private readonly RegisterProduct _command = new(
            "Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements.",
            "Lunch Box",
            25,
            $"MLC-LB{++Count:000}-STD"
        );

        private HttpResponseMessage _result;
        private static ushort Count;

        public WhenCreatingAProduct(IntegrationTestingFactory<Startup> factory) : base(
            factory,
            "api/sales"
        )
        {
        }

        #endregion

        #region Public Interface

        public Task DisposeAsync() => Task.CompletedTask;

        public async Task InitializeAsync()
        {
            _result = await HttpClient.PostAsJsonAsync("products", _command);
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ThenContentIsAssigned()
        {
            var product = _result.Content.ReadFromJsonAsync<ProductDto>().Result;

            product.Should().NotBeNull();
        }

        [Fact]
        public void ThenLocationHeaderIsAssigned()
        {
            _result.Headers.Location.Should().NotBeNull();
        }

        [Fact]
        public async void ThenTheProductIsRetrievable()
        {
            var product = await HttpClient.GetFromJsonAsync<ProductDto>($"products/{_command.Sku}");

            product.Should().NotBeNull();
        }

        #endregion
    }
}
