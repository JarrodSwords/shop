using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Shop.Catalog.Services;
using Xunit;

namespace Shop.Api.Spec.Sales
{
    [Collection("storage")]
    public class WhenCreatingAProduct : PostFixture<ProductDto>
    {
        #region Core

        private const string Resource = "products";

        private readonly RegisterProduct _command = new(
            "A Foo description",
            $"Foo {++_count}",
            25
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

        public override async Task InitializeAsync()
        {
            Result = await HttpClient.PostAsJsonAsync(Resource, _command);
        }

        [Fact]
        public async void ThenTheProductIsRetrievable()
        {
            var recordName = _command.Name.Trim().Replace(' ', '-').ToLower();
            var product = await HttpClient.GetFromJsonAsync<ProductDto>($"{Resource}/{recordName}");

            product.Should().NotBeNull();
        }

        #endregion
    }
}
