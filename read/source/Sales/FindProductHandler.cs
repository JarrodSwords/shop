using System.Data;
using Dapper;
using Shop.Sales.Services;
using Shop.Shared;

namespace Shop.Read.Sales
{
    public class FindProductHandler : Handler<FindProduct, ProductDto>
    {
        private const string FindProduct = @"
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
            connection.QuerySingleOrDefault<ProductDto>(FindProduct, args);

        #endregion
    }
}
