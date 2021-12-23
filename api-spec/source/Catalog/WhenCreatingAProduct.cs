using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Shop.Catalog.Services;
using Xunit;

namespace Shop.Api.Spec.Catalog
{
    [Collection("storage")]
    public class WhenCreatingAProduct : PostFixture<ProductDto>
    {
        #region Core

        private const string Resource = "products";

        private readonly RegisterProduct _command = new(
            "Bar",
            "A Foo description",
            $"Foo {++_count}",
            25,
            "SM"
        );

        private static ushort _count;

        public WhenCreatingAProduct(IntegrationTestingFactory<Startup> factory) : base(
            factory,
            "api"
        )
        {
        }

        #endregion

        #region Test Methods

        public override async Task InitializeAsync()
        {
            Result = await HttpClient.PostAsJsonAsync($"catalog/{Resource}", _command);
        }

        [Fact]
        public async void ThenProductExistsInCatalog()
        {
            var recordName = _command.Name.Trim().Replace(' ', '-').ToLower();
            var product = await HttpClient.GetFromJsonAsync<ProductDto>($"catalog/{Resource}/{recordName}");

            product.Should().NotBeNull();
        }

        [Fact]
        public async void ThenProductExistsInSales()
        {
            var recordName = _command.Name.Trim().Replace(' ', '-').ToLower();
            var product = await HttpClient.GetFromJsonAsync<ProductDto>($"sales/{Resource}/{recordName}");

            product.Should().NotBeNull();
        }

        [Fact]
        public async void ThenProductIsCorrectInSales()
        {
            var recordName = _command.Name.Trim().Replace(' ', '-').ToLower();
            var product = await HttpClient.GetFromJsonAsync<Shop.Sales.Services.ProductDto>(
                $"sales/{Resource}/{recordName}"
            );

            product.Price.Should().Be(_command.Price);
        }

        #endregion
    }
}
