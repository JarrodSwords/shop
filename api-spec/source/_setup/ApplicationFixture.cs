using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Shop.Api.Spec
{
    /// <summary>
    ///     Fixture for testing application services including commands and queries.
    /// </summary>
    public abstract class ApplicationFixture : IClassFixture<IntegrationTestingFactory<Startup>>, IDisposable
    {
        private readonly IServiceScope _scope;

        #region Creation

        protected ApplicationFixture(WebApplicationFactory<Startup> factory)
        {
            _scope = factory.Services.CreateScope();
        }

        #endregion

        #region Public Interface

        public T Resolve<T>() => _scope.ServiceProvider.GetRequiredService<T>();

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            _scope?.Dispose();
        }

        #endregion
    }
}
