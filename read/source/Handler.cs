using System.Data;
using Jgs.Cqrs;
using Microsoft.Data.SqlClient;
using Shop.Shared;

namespace Shop.Read
{
    public abstract class Handler<T, TResult> : IQueryHandler<T, TResult> where T : IQuery
    {
        private readonly string _connectionString;

        #region Creation

        protected Handler(IConnectionStringProvider connectionStringProvider)
        {
            _connectionString = connectionStringProvider.GetConnectionString();
        }

        #endregion

        #region Public Interface

        public abstract TResult Execute(IDbConnection connection, T args);

        #endregion

        #region IQueryHandler<T,TResult> Implementation

        public TResult Handle(T query)
        {
            using var connection = new SqlConnection(_connectionString);
            var result = Execute(connection, query);
            return result;
        }

        #endregion
    }
}
