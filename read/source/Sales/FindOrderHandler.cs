using System.Data;
using Dapper;
using Shop.Sales.Services;
using Shop.Shared;

namespace Shop.Read.Sales
{
    public class FindOrderHandler : Handler<FindOrder, OrderDto>
    {
        private const string FindOrder = @"
select o.Id
     , c.Email
     , o.Subtotal
     , o.Tip
     , o.Total
  from [order] o
  join customer c
    on c.Id = o.CustomerId
 where o.Id = @Id";

        #region Creation

        public FindOrderHandler(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        #endregion

        #region Public Interface

        public override OrderDto Execute(IDbConnection connection, FindOrder args) =>
            connection.QuerySingleOrDefault<OrderDto>(FindOrder, args);

        #endregion
    }
}
