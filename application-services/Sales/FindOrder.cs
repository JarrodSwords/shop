using System;
using Jgs.Cqrs;

namespace Shop.ApplicationServices.Sales
{
    public record FindOrder(Guid Id) : IQuery
    {
        #region Static Interface

        public static implicit operator FindOrder(Guid source) => new(source);

        #endregion

        public class Handler : IQueryHandler<FindOrder, OrderDto>
        {
            #region IQueryHandler<FindOrder,OrderDto> Implementation

            public OrderDto Handle(FindOrder query) => new();

            #endregion
        }
    }
}
