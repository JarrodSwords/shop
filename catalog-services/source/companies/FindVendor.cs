using System;
using Jgs.Cqrs;

namespace Shop.Catalog.Services
{
    public record FindVendor(Guid Id) : IQuery
    {
        #region Static Interface

        public static implicit operator FindVendor(Guid source) => new(source);

        #endregion
    }
}
