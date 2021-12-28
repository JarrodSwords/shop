using Shop.Catalog;

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

        public ICompanyRepository Create(Shop.Catalog.Company company)
        {
            base.Create(company);
            return this;
        }

        #endregion
    }
}
