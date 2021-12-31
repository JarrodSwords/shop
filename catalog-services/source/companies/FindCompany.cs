using System;
using Jgs.Cqrs;

namespace Shop.Catalog.Services
{
    public record FindCompany(Guid Id) : IQuery
    {
        #region Static Interface

        public static implicit operator FindCompany(Guid source) => new(source);

        #endregion
    }

    public record FindCompanyByName(string Name) : IQuery
    {
        #region Static Interface

        public static implicit operator FindCompanyByName(string source) => new(source);

        #endregion
    }
}
