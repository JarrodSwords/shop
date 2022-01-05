using System.Data;
using Dapper;
using Shop.Catalog.Services;
using Shop.Shared;

namespace Shop.Read.Catalog
{
    public class FindVendorHandler : Handler<FindVendor, VendorDto>
    {
        private const string Query = @"
select Id
     , Name
  from Vendor
 where Id = @Id";

        #region Creation

        public FindVendorHandler(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        #endregion

        #region Public Interface

        public override VendorDto Execute(IDbConnection connection, FindVendor args) =>
            connection.QuerySingleOrDefault<VendorDto>(Query, args);

        #endregion
    }
}
