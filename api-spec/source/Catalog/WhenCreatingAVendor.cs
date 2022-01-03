using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Shop.Catalog.Services;
using Xunit;

namespace Shop.Api.Spec.Catalog
{
    [Collection("storage")]
    public class WhenCreatingAVendor : PostFixture<VendorDto>
    {
        #region Core

        private const string Resource = "vendors";
        private readonly RegisterVendor _command = new("Foo", "f");

        public WhenCreatingAVendor(IntegrationTestingFactory<Startup> factory) : base(
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
        public async void ThenVendorExists()
        {
            var id = Result.Content.ReadFromJsonAsync<VendorDto>().Result.Id;
            var vendor = await HttpClient.GetFromJsonAsync<VendorDto>($"{Resource}/{id}");

            vendor.Should().NotBeNull();
        }

        #endregion
    }
}
