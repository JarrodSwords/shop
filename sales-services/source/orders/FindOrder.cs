using System;
using Jgs.Cqrs;

namespace Shop.Sales.Services
{
    public record FindOrder(Guid Id) : IQuery
    {
        #region Static Interface

        public static implicit operator FindOrder(Guid source) => new(source);

        #endregion
    }
}
