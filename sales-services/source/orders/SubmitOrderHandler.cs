using Jgs.Cqrs;
using Jgs.Functional.Explicit;
using Shop.Sales.Orders;
using Shop.Shared;

namespace Shop.Sales.Services
{
    public class SubmitOrderHandler : ICommandHandler<SubmitOrder, Result<OrderSubmitted, Error>>
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

        #region ICommandHandler<SubmitOrder,Result<OrderSubmitted,Error>> Implementation

        public Result<OrderSubmitted, Error> Handle(SubmitOrder args)
        {
            _builder.With(args);

            new Order.Director()
                .With(_builder)
                .ConfigureSubmitOrder();

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
