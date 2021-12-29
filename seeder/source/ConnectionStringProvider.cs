using Microsoft.Extensions.Configuration;
using Shop.Shared;

namespace Shop.Seeder
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
