using Dapper;
using Shop.Sales.Services;
using Shop.Shared;

namespace Shop.Read.Sales
{
    public class FindCustomerHandler : Handler<FindCustomer, CustomerDto>
    {
        private const string FindCustomer = @"
select Email
     , FirstName
     , LastName
  from customer
 where Email = @Email";

        #region Creation

        public FindCustomerHandler(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        #endregion

        #region Public Interface

        public override CustomerDto Handle(FindCustomer query)
        {
            using var connection = CreateConnection();

            return connection.QuerySingleOrDefault<CustomerDto>(FindCustomer, query);
        }

        #endregion
    }
}
