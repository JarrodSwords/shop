using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Shop.Catalog.Services;
using Xunit;

namespace Shop.Api.Spec.Catalog
{
    [Collection("storage")]
    public class WhenCreatingACompany : PostFixture<CompanyDto>
    {
        #region Core

        private const string Resource = "companies";
        private readonly RegisterCompany _command = new("Foo", "f");

        public WhenCreatingACompany(IntegrationTestingFactory<Startup> factory) : base(
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
        public async void ThenCompanyExists()
        {
            var id = Result.Content.ReadFromJsonAsync<CompanyDto>().Result.Id;
            var company = await HttpClient.GetFromJsonAsync<CompanyDto>($"{Resource}/{id}");

            company.Should().NotBeNull();
        }

        #endregion
    }
}
