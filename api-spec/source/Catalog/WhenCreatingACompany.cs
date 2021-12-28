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
            var value = Result.Content.ReadFromJsonAsync<CompanyDto>().Result;
            var company = await HttpClient.GetFromJsonAsync<CompanyDto>($"{Resource}/{value.Id}");

            company.Should().NotBeNull();
        }

        #endregion
    }
}
