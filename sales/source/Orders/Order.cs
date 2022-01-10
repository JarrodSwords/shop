using System;
using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;
using Jgs.Functional.Explicit;
using Shop.Sales.Orders.State;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public partial class Order : Aggregate
    {
        private readonly List<LineItem> _lineItems = new();

        private static readonly Dictionary<OrderStates, Func<OrderState>> StateFactory =
            new()
            {
                { OrderStates.AwaitingConfirmation, () => new AwaitingConfirmation() },
                { OrderStates.Canceled, () => new Canceled() }
            };

        private OrderState _state;

        #region Creation

        private Order(
            Id customerId,
            IEnumerable<LineItem> lineItems,
            OrderStates states = default,
            Money tip = default
        )
        {
            CustomerId = customerId;

            if (lineItems != null)
                _lineItems.AddRange(lineItems);

            states = states == default
                ? OrderStates.AwaitingConfirmation
                : states;

            Set(StateFactory[states]());

            Tip = tip ?? Money.Zero;
        }

        public static Result<Order, Error> From(
            Id customerId,
            List<Id> customerIds,
            OrderStates states = default
        )
        {
            if (customerId is null)
                return Error.Required(nameof(customerId));

            if (customerIds.All(x => x != customerId))
                return ErrorExtensions.CustomerNotFound();

            return new Order(customerId, null, states);
        }

        #endregion

        #region Public Interface

        public Id CustomerId { get; }
        public IReadOnlyCollection<LineItem> LineItems => _lineItems.AsReadOnly();
        public OrderStates States => _state.GetStates();
        public Money Subtotal => _lineItems.Aggregate(Money.Zero, (current, li) => current + li.Total);
        public Money Tip { get; }
        public Money Total => Subtotal + Tip;

        public Result<Error> Cancel() => _state.Cancel();

        public void Set(OrderState state)
        {
            _state = state;
            _state.Set(this);
        }

        #endregion
    }
}
