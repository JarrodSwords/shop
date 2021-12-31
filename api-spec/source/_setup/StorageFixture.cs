using System;
using System.Data.Common;
using Jgs.Ddd;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shop.Catalog;
using Shop.Shared;
using Shop.Write;
using Company = Shop.Catalog.Company;
using Product = Shop.Catalog.Product;
using Sku = Shop.Catalog.Sku;

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

            var productBuilder = new ProductBuilder();
            productBuilder.With(ProductCategories.Box);

            Context.Product.Add(
                productBuilder
                    .With((Name) "Lunch Box")
                    .With((Description) "a lunch box")
                    .With((Token) "lun")
                    .Build()
            );

            Context.SaveChanges();
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Context.Dispose();
        }

        #endregion

        public record ProductBuilder : IProductBuilder
        {
            private ProductCategories _categories;
            private Company _company = Company.ManyLoves;
            private Description _description;
            private Name _name;
            private Size _size;
            private Token _skuToken;

            #region Public Interface

            public Product Build() => Product.From(this).Value;

            public ProductBuilder With(ProductCategories categories)
            {
                _categories = categories;
                return this;
            }

            public ProductBuilder With(Company company)
            {
                _company = company;
                return this;
            }

            public ProductBuilder With(Description description)
            {
                _description = description;
                return this;
            }

            public ProductBuilder With(Name name)
            {
                _name = name;
                return this;
            }

            public ProductBuilder With(Size size)
            {
                _size = size;
                return this;
            }

            public ProductBuilder With(Token skuToken)
            {
                _skuToken = skuToken;
                return this;
            }

            #endregion

            #region IProductBuilder Implementation

            public ProductCategories GetCategories() => _categories;
            public Id GetCompanyId() => _company.Id;
            public Description GetDescription() => _description;
            public Name GetName() => _name;
            public Size GetSize() => _size;

            public Sku GetSku() =>
                Sku.Create(
                    _company.SkuToken,
                    _categories.GetToken(),
                    _skuToken
                );

            #endregion
        }
    }
}
