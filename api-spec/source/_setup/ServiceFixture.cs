using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Shop.Api.Spec
{
    public abstract class ServiceFixture : IClassFixture<IntegrationTestingFactory<Startup>>, IDisposable
    {
        private readonly IServiceScope _scope;

        #region Creation

        protected ServiceFixture(WebApplicationFactory<Startup> factory)
        {
            _scope = factory.Services.CreateScope();
        }

        #endregion

        #region Protected Interface

        protected IServiceProvider ServiceProvider => _scope.ServiceProvider;

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            _scope?.Dispose();
        }

        #endregion
    }
}
