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
                .CreateLineItem("mlc-s-b", quantity: baguettes)
                .CreateLineItem("mlc-b-cpl", quantity: couplesBoxes)
                .CreateLineItem("mlc-bd-dst", quantity: dessertBoxes)
                .CreateLineItem("mlc-b-fam", quantity: familyBoxes)
                .CreateLineItem("mlc-b-lun", quantity: lunchBoxes)
                .CreateLineItem("mlc-b-pty", quantity: partyBoxes)
                .CreateLineItem($"mlc-ds-stw-{strawberries}", quantity: strawberries);

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
