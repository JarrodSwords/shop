using Jgs.Cqrs;
using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Catalog.Services
{
    public record RegisterCompany(
        string Name,
        string SkuToken
    ) : ICommand, ICompanyBuilder
    {
        #region ICompanyBuilder Implementation

        public Id GetId() => default;
        public Name GetName() => Name;
        public Token GetSkuToken() => SkuToken;

        #endregion

        public class Handler : Handler<RegisterCompany, Id>
        {
            #region Creation

            public Handler(IUnitOfWork uow) : base(uow)
            {
            }

            #endregion

            #region Public Interface

            public override Id Handle(RegisterCompany command)
            {
                var company = Company.From(command).Value;

                Uow.Companies.Create(company);
                Uow.Commit();

                return company.Id;
            }

            #endregion
        }
    }
}
