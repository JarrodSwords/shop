using Dapper;
using Shop.Sales.Services;
using Shop.Shared;

namespace Shop.Read.Sales
{
    public class FindProductHandler : Handler<FindProduct, ProductDto>
    {
        private const string FindProduct = @"
select Description
     , Name
     , Price
     , RecordName
  from Product
 where RecordName = @RecordName";

        #region Creation

        public FindProductHandler(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        #endregion

        #region Public Interface

        public override ProductDto Handle(FindProduct query)
        {
            using var connection = CreateConnection();

            return connection.QuerySingleOrDefault<ProductDto>(FindProduct, query);
        }

        #endregion
    }
}
