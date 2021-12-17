using System;
using System.Net.Http;
using Xunit;

namespace Shop.Api.Spec
{
    public abstract class WebApiFixture : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        #region Creation

        protected WebApiFixture(
            TestWebApplicationFactory<Startup> factory,
            string uri = default
        )
        {
            if (uri != default)
                factory.ClientOptions.BaseAddress = new Uri($"http://localhost/{uri}/");


            HttpClient = factory.CreateClient();
        }

        #endregion

        #region Protected Interface

        protected HttpClient HttpClient { get; }

        #endregion
    }
}
