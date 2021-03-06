using System.Data;
using Dapper;
using Shop.Sales.Services;
using Shop.Sales.Services.Products;
using Shop.Shared;

namespace Shop.Read.Sales
{
    public class FindProductHandler : Handler<FindProduct, ProductDto>
    {
        private const string Query = @"
select Price
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
