using System;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shop.Write;
using Company = Shop.Catalog.Company;
using Product = Shop.Catalog.Product;

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

        #region Creation

        public StorageFixture()
        {
            CreateDatabase();
            SeedDatabase();
        }

        #endregion

        #region Private Interface

        private Context Context { get; set; }

        private Context CreateContext(DbTransaction transaction = null)
        {
            var connection = new SqlConnection(ConnectionString);
            Context = new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connection).Options);

            if (transaction != null)
                Context.Database.UseTransaction(transaction);

            return Context;
        }

        private void CreateDatabase()
        {
            lock (Lock)
            {
                Context = CreateContext();

                Context.Database.EnsureDeleted();
                Context.Database.Migrate();

                Context.SaveChanges();
            }
        }

        private void SeedDatabase()
        {
            Context.Company.Add(Company.ManyLoves);

            Context.Product.Add(Product.LunchBox);

            Context.SaveChanges();
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Context.Dispose();
        }

        #endregion
    }
}
