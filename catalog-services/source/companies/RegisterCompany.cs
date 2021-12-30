using System;
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

        public record CompanyDto(Guid Id);

        public class Handler : Handler<RegisterCompany, CompanyDto>
        {
            #region Creation

            public Handler(IUnitOfWork uow) : base(uow)
            {
            }

            #endregion

            #region Public Interface

            public override CompanyDto Handle(RegisterCompany args)
            {
                var company = Company.From(args).Value;

                Uow.Companies.Create(company);
                Uow.Commit();

                return new(company.Id);
            }

            #endregion
        }
    }
}
