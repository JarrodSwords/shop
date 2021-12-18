using System.Collections.Generic;
using Dapper;
using Shop.Sales.Services;
using Shop.Shared;

namespace Shop.Read.Sales
{
    public class FetchCustomersHandler : Handler<FetchCustomers, IEnumerable<CustomerDto>>
    {
        private const string FetchCustomers = @"
select Email
     , FirstName
     , LastName
  from customer";

        #region Creation

        public FetchCustomersHandler(IConnectionStringProvider connectionStringProvider) : base(
            connectionStringProvider
        )
        {
        }

        #endregion

        #region Public Interface

        public override IEnumerable<CustomerDto> Handle(FetchCustomers query)
        {
            using var connection = CreateConnection();

            return connection.Query<CustomerDto>(FetchCustomers, query);
        }

        #endregion
    }
}
