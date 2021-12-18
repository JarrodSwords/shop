using Microsoft.Extensions.Configuration;
using Shop.Shared;

namespace Shop.Api
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        #region Creation

        public ConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region IConnectionStringProvider Implementation

        public string GetConnectionString() => _configuration.GetConnectionString("Shop");

        #endregion
    }
}
