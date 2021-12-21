using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Shop.Api.Spec
{
    public abstract class PostFixture<T> : WebApiFixture, IAsyncLifetime
    {
        #region Core

        protected HttpResponseMessage Result;

        protected PostFixture(IntegrationTestingFactory<Startup> factory, string uri = default) : base(factory, uri)
        {
        }

        #endregion

        #region Public Interface

        public Task DisposeAsync() => Task.CompletedTask;
        public abstract Task InitializeAsync();

        #endregion

        #region Test Methods

        [Fact]
        public void ThenContentIsAssigned()
        {
            var value = Result.Content.ReadFromJsonAsync<T>().Result;

            value.Should().NotBeNull();
        }

        [Fact]
        public void ThenLocationHeaderIsAssigned()
        {
            Result.Headers.Location.Should().NotBeNull();
        }

        #endregion
    }
}
