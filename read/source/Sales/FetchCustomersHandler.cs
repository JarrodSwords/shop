using System.Collections.Generic;
using System.Data;
using Dapper;
using Shop.Sales.Services;
using Shop.Shared;

namespace Shop.Read.Sales
{
    public class FetchCustomersHandler : Handler<FetchCustomers, IEnumerable<CustomerDto>>
    {
        private const string Query = @"
select Email
  from customer";

        #region Creation

        public FetchCustomersHandler(IConnectionStringProvider connectionStringProvider) : base(
            connectionStringProvider
        )
        {
        }

        #endregion

        #region Public Interface

        public override IEnumerable<CustomerDto> Execute(IDbConnection connection, FetchCustomers args) =>
            connection.Query<CustomerDto>(Query, args);

        #endregion
    }
}
