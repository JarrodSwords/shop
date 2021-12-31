using Jgs.Ddd;
using Shop.Catalog;
using CatalogCompany = Shop.Catalog.Company;

namespace Shop.Write.Catalog
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        #region Creation

        public CompanyRepository(Context context) : base(context)
        {
        }

        #endregion

        #region ICompanyRepository Implementation

        public ICompanyRepository Create(CatalogCompany company)
        {
            base.Create(company);
            return this;
        }

        public CatalogCompany Find(Id id) => base.Find(id);

        #endregion
    }
}
