using System.Data;
using Jgs.Cqrs;
using Microsoft.Data.SqlClient;
using Shop.Shared;

namespace Shop.Read
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
}
