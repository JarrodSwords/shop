using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Shop.Sales.Services;
using Xunit;

namespace Shop.Api.Spec.Sales
{
    [Collection("storage")]
    public class WhenCreatingAProduct : PostFixture<ProductDto>
    {
        #region Core

        private const string Resource = "products";

        private readonly RegisterProduct _command = new(
            "Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements.",
            "Lunch Box",
            25,
            $"MLC-LB{++_count:000}-STD"
        );

        private static ushort _count;

        public WhenCreatingAProduct(IntegrationTestingFactory<Startup> factory) : base(
            factory,
            "api/sales"
        )
        {
        }

        #endregion

        #region Test Methods

        public override async Task InitializeAsync()
        {
            Result = await HttpClient.PostAsJsonAsync(Resource, _command);
        }

        [Fact]
        public async void ThenTheProductIsRetrievable()
        {
            var product = await HttpClient.GetFromJsonAsync<ProductDto>($"{Resource}/{_command.Sku}");

            product.Should().NotBeNull();
        }

        #endregion
    }
}
