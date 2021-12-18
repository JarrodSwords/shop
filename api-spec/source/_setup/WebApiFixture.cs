using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Shop.Api.Spec
{
    public abstract class WebApiFixture : IClassFixture<IntegrationTestingFactory<Startup>>
    {
        #region Creation

        protected WebApiFixture(
            WebApplicationFactory<Startup> factory,
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
