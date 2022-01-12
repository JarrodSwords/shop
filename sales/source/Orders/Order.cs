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
            IEnumerable<LineItem> lineItems,
            OrderState state = default,
            Money tip = default
        )
        {
            CustomerId = customerId;

            if (lineItems != null)
                _lineItems.AddRange(lineItems);

            State = state == default
                ? OrderState.AwaitingConfirmation
                : state;

            Tip = tip ?? Money.Zero;
        }

        public static Result<Order, Error> From(
            Id customerId,
            List<Id> customerIds,
            OrderState states = default,
            params LineItem[] lineItems
        )
        {
            if (customerId is null)
                return Error.Required(nameof(customerId));

            if (customerIds.All(x => x != customerId))
                return ErrorExtensions.CustomerNotFound();

            return new Order(customerId, lineItems, states);
        }

        #endregion

        #region Public Interface

        public Money AmountDue { get; private set; }
        public Id CustomerId { get; }
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

        public Money Subtotal => _lineItems.Aggregate(Money.Zero, (current, li) => current + li.Total);
        public Money Tip { get; }
        public Money Total => Subtotal + Tip;

        #endregion

        #region IOrderable Implementation

        public Result<Error> ApplyPayment(Money money) => _orderable.ApplyPayment(money);
        public Result<Error> Cancel() => _orderable.Cancel();
        public Result<Error> Confirm() => _orderable.Confirm();

        #endregion
    }
}
