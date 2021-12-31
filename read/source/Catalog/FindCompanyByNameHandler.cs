using System.Data;
using Dapper;
using Shop.Catalog.Services;
using Shop.Shared;

namespace Shop.Read.Catalog
{
    public class FindCompanyByNameHandler : Handler<FindCompanyByName, CompanyDto>
    {
        private const string FindCompany = @"
select Id
     , Name
  from Company
 where Name = @Name";

        #region Creation

        public FindCompanyByNameHandler(IConnectionStringProvider connectionStringProvider) : base(
            connectionStringProvider
        )
        {
        }

        #endregion

        #region Public Interface

        public override CompanyDto Execute(IDbConnection connection, FindCompanyByName args) =>
            connection.QuerySingleOrDefault<CompanyDto>(FindCompany, args);

        #endregion
    }
}
