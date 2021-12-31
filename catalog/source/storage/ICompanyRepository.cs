using Jgs.Ddd;

namespace Shop.Catalog
{
    public interface ICompanyRepository
    {
        ICompanyRepository Create(Company company);
        Company Find(Id companyId);
    }
}
