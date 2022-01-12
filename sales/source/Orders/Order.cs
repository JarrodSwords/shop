using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;
using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public partial class Order : Aggregate, IOrderable
    {
        private readonly List<LineItem> _lineItems = new();
        private Orderable _orderable;
        private OrderState _state;

        #region Creation

        private Order(
            Id customerId,
            OrderState state = default,
            Finances finances = default,
            params LineItem[] lineItems
        )
        {
            CustomerId = customerId;

            if (lineItems != null)
                _lineItems.AddRange(lineItems);

            State = state == default
                ? OrderState.AwaitingConfirmation
                : state;

            Finances = finances ?? Finances.From(lineItems);
        }

        public static Result<Order, Error> From(
            Id customerId,
            List<Id> customerIds,
            OrderState state = default,
            params LineItem[] lineItems
        )
        {
            if (customerId is null)
                return Error.Required(nameof(customerId));

            if (customerIds.All(x => x != customerId))
                return ErrorExtensions.CustomerNotFound();

            return new Order(customerId, state, lineItems: lineItems);
        }

        #endregion

        #region Public Interface

        public Id CustomerId { get; }
        public Finances Finances { get; private set; }
        public IReadOnlyCollection<LineItem> LineItems => _lineItems.AsReadOnly();

        public OrderState State
        {
            get => _state;
            private set
            {
                _state = value;
                _orderable = Orderable.From(_state);
                _orderable.Set(this);
            }
        }

        #endregion

        #region IOrderable Implementation

        public Result<Error> ApplyPayment(Money value) => _orderable.ApplyPayment(value);
        public Result<Error> Cancel() => _orderable.Cancel();
        public Result<Error> Confirm() => _orderable.Confirm();

        #endregion
    }
}
