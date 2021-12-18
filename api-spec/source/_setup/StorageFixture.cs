using System;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shop.Write;

namespace Shop.Api.Spec
{
    /// <summary>
    ///     Creates the test database once per test session
    /// </summary>
    public class StorageFixture : IDisposable
    {
        private const string ConnectionString =
            "Data Source=BECKY\\SQLEXPRESS;Initial Catalog=ShopTest;Integrated Security=True;Connect Timeout=60;";

        private static readonly object Lock = new();
        private static bool _databaseInitialized;

        #region Creation

        public StorageFixture()
        {
            Connection = new SqlConnection(ConnectionString);

            Seed();

            Connection.Open();
        }

        #endregion

        #region Public Interface

        public DbConnection Connection { get; }

        public Context CreateContext(DbTransaction transaction = null)
        {
            var context = new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(Connection).Options);

            if (transaction != null)
                context.Database.UseTransaction(transaction);

            return context;
        }

        #endregion

        #region Private Interface

        private void Seed()
        {
            lock (Lock)
            {
                if (_databaseInitialized)
                    return;

                using var context = CreateContext();
                context.Database.EnsureDeleted();
                context.Database.Migrate();

                _databaseInitialized = true;
            }
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose() => Connection.Dispose();

        #endregion
    }
}
