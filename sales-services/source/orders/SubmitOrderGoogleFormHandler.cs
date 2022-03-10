using Jgs.Cqrs;
using Jgs.Functional.Explicit;
using Shop.Sales.Orders;
using Shop.Shared;

namespace Shop.Sales.Services
{
    public class SubmitOrderGoogleFormHandler : ICommandHandler<SubmitOrderGoogleForm, Result<OrderSubmitted, Error>>
    {
        private readonly Order.Builder _builder;
        private readonly IUnitOfWork _uow;

        #region Creation

        public SubmitOrderGoogleFormHandler(
            Order.Builder builder,
            IUnitOfWork uow
        )
        {
            _builder = builder;
            _uow = uow;
        }

        #endregion

        #region ICommandHandler<SubmitOrderGoogleForm,Result<OrderSubmitted,Error>> Implementation

        public Result<OrderSubmitted, Error> Handle(SubmitOrderGoogleForm args)
        {
            _builder.With(args.Email);

            var (_, _, baguettes, couplesBoxes, dessertBoxes, familyBoxes, lunchBoxes, partyBoxes, strawberries, _
                ) = args;

            _builder
                .CreateLineItems(baguettes, "mlc-s-b")
                .CreateLineItems(couplesBoxes, "mlc-b-cpl")
                .CreateLineItems(dessertBoxes, "mlc-bd-dst")
                .CreateLineItems(familyBoxes, "mlc-b-fam")
                .CreateLineItems(lunchBoxes, "mlc-b-lun")
                .CreateLineItems(partyBoxes, "mlc-b-pty")
                .CreateLineItems(strawberries, $"mlc-ds-stw-{strawberries}");

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
