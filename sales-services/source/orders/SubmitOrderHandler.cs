using Jgs.Cqrs;
using Jgs.Functional;
using Shop.Sales.Orders;

namespace Shop.Sales.Services
{
    public class SubmitOrderHandler : ICommandHandler<SubmitOrder, Result<OrderSubmitted>>
    {
        private readonly SubmitOrder.OrderBuilder _builder;
        private readonly IUnitOfWork _uow;

        #region Creation

        public SubmitOrderHandler(
            SubmitOrder.OrderBuilder builder,
            IUnitOfWork uow
        )
        {
            _builder = builder;
            _uow = uow;
        }

        #endregion

        #region ICommandHandler<SubmitOrder,Result<OrderSubmitted>> Implementation

        public Result<OrderSubmitted> Handle(SubmitOrder args)
        {
            _builder.With(args);

            new Order.Director()
                .With(_builder)
                .ConfigureSubmitOrder();

            var result = _builder.Build();

            if (result.IsFailure)
                return Result.Failure<OrderSubmitted>("Order submission failed.");

            _uow.Orders.Create(result.Value);
            _uow.Commit();

            return Result.Success(new OrderSubmitted(result.Value.Id));
        }

        #endregion
    }
}
