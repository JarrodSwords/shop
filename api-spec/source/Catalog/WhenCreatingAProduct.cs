using System.Net.Http.Json;
using FluentAssertions;
using Shop.Catalog.Services;
using Xunit;

namespace Shop.Api.Spec.Catalog
{
    [Collection("storage")]
    public class WhenCreatingAProduct : WebApiFixture
    {
        #region Core

        private const string Resource = "products";

        private readonly RegisterProduct _command = new(
            "Bar",
            "A Foo description",
            $"Foo {++_count}",
            "f"
        );

        private static ushort _count;

        public WhenCreatingAProduct(IntegrationTestingFactory<Startup> factory) : base(
            factory,
            "api/catalog"
        )
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async void ThenProductExistsInCatalog()
        {
            var result = await HttpClient.PostAsJsonAsync($"{Resource}", _command);

            var sku = result.Content.ReadFromJsonAsync<ProductDto>().Result.Sku;

            var product = await HttpClient.GetFromJsonAsync<ProductDto>($"{Resource}/{sku}");

            product.Should().NotBeNull();
        }

        #endregion
    }
}
