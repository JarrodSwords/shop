using System.Data;
using Dapper;
using Shop.Sales.Services;
using Shop.Shared;

namespace Shop.Read.Sales
{
    public class FindCustomerHandler : Handler<FindCustomer, CustomerDto>
    {
        private const string FindCustomer = @"
select Email
  from customer
 where Email = @Email";

        #region Creation

        public FindCustomerHandler(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        #endregion

        #region Public Interface

        public override CustomerDto Execute(IDbConnection connection, FindCustomer args) =>
            connection.QuerySingleOrDefault<CustomerDto>(FindCustomer, args);

        #endregion
    }
}
