using System.Data;
using Dapper;
using Jgs.Cqrs;
using Microsoft.Data.SqlClient;
using Shop.Sales.Services;
using Shop.Shared;

namespace Shop.Read.Sales
{
    public abstract class Handler<T, TResult> : IQueryHandler<T, TResult> where T : IQuery
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        #region Creation

        protected Handler(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        #endregion

        #region Public Interface

        public IDbConnection CreateConnection() => new SqlConnection(_connectionStringProvider.GetConnectionString());

        #endregion

        #region IQueryHandler<T,TResult> Implementation

        public abstract TResult Handle(T query);

        #endregion
    }

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

    public class FindOrderHandler : Handler<FindOrder, OrderDto>
    {
        private const string FindOrder = @"
select o.Id
     , c.Email
     , o.LunchBoxes
	 , o.CouplesBoxes
	 , o.FamilyBoxes
	 , o.PartyBoxes
	 , o.DessertBoxes
     , o.Baguettes
	 , o.Strawberries
	 , o.IsGift
	 , o.IsSpecialOccasion
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

        public override OrderDto Handle(FindOrder query)
        {
            using var connection = CreateConnection();

            return connection.QuerySingleOrDefault<OrderDto>(FindOrder, query);
        }

        #endregion
    }
}
