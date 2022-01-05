using System.Data;
using Dapper;
using Shop.Catalog.Services;
using Shop.Shared;

namespace Shop.Read.Catalog
{
    public class FindProductHandler : Handler<FindProduct, ProductDto>
    {
        private const string Query = @"
select Description
     , Name
     , Sku
  from Product
 where Sku = @Sku";

        #region Creation

        public FindProductHandler(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        #endregion

        #region Public Interface

        public override ProductDto Execute(IDbConnection connection, FindProduct args) =>
            connection.QuerySingleOrDefault<ProductDto>(Query, args);

        #endregion
    }
}
