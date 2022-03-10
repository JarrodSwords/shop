using Jgs.Cqrs;
using Jgs.Functional.Explicit;
using Shop.Sales.Orders;
using Shop.Shared;

namespace Shop.Sales.Services
{
    public class SubmitOrderWebsiteHandler : ICommandHandler<SubmitOrderWebsite, Result<OrderSubmitted, Error>>
    {
        private readonly Order.Builder _builder;
        private readonly IUnitOfWork _uow;

        #region Creation

        public SubmitOrderWebsiteHandler(
            Order.Builder builder,
            IUnitOfWork uow
        )
        {
            _builder = builder;
            _uow = uow;
        }

        #endregion

        #region ICommandHandler<SubmitOrderWebsite,Result<OrderSubmitted,Error>> Implementation

        public Result<OrderSubmitted, Error> Handle(SubmitOrderWebsite args)
        {
            var (email, lineItems) = args;

            _builder.With(email);

            foreach (var lineItem in lineItems)
            {
                var (sku, exclusions) = lineItem;
                _builder.CreateLineItem(sku, exclusions);
            }

            var result = _builder.Build();

            if (result.IsFailure)
                return result.Error;

            var order = result.Value;
            order.Submit();

            _uow.Orders.Create(order);
            _uow.Commit();

            return new OrderSubmitted(order.Id);
        }

        #endregion
    }
}
