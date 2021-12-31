using Jgs.Ddd;
using Shop.Catalog;
using Shop.Shared;
using CatalogCompany = Shop.Catalog.Company;

namespace Shop.Write
{
    public partial class Company : ICompanyBuilder
    {
        #region Creation

        private Company(CatalogCompany source) : base(source.Id)
        {
            Name = source.Name;
            SkuToken = source.SkuToken;
        }

        #endregion

        #region ICompanyBuilder Implementation

        public Id GetId() => Id;
        public Name GetName() => Name;
        public Token GetSkuToken() => SkuToken;

        #endregion

        #region Static Interface

        public static implicit operator Company(CatalogCompany source) => new(source);
        public static implicit operator CatalogCompany(Company source) => CatalogCompany.From(source).Value;

        #endregion
    }
}
