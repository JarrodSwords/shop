using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
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

    public abstract class ServiceFixture : IClassFixture<IntegrationTestingFactory<Startup>>, IDisposable
    {
        private readonly IServiceScope Scope;

        #region Creation

        protected ServiceFixture(WebApplicationFactory<Startup> factory)
        {
            Scope = factory.Services.CreateScope();
        }

        #endregion

        #region Protected Interface

        protected IServiceProvider ServiceProvider => Scope.ServiceProvider;

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Scope?.Dispose();
        }

        #endregion
    }
}
