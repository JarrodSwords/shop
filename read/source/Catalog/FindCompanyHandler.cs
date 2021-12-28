using System.Data;
using Dapper;
using Shop.Catalog.Services;
using Shop.Shared;

namespace Shop.Read.Catalog
{
    public class FindCompanyHandler : Handler<FindCompany, CompanyDto>
    {
        private const string FindCompany = @"
select Id
     , Name
  from Company
 where Id = @Id";

        #region Creation

        public FindCompanyHandler(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        #endregion

        #region Public Interface

        public override CompanyDto Execute(IDbConnection connection, FindCompany args) =>
            connection.QuerySingleOrDefault<CompanyDto>(FindCompany, args);

        #endregion
    }
}
