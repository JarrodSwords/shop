using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;
using Jgs.Functional.Explicit;
using Shop.Shared;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public partial class Order : Aggregate, IOrderable
    {
        private readonly List<LineItem> _lineItems = new();
        private readonly Orderable _orderable;

        #region Creation

        private Order(
            Id customerId,
            OrderState state,
            Finances finances = default,
            params LineItem[] lineItems
        )
        {
            CustomerId = customerId;

            if (lineItems != null)
                _lineItems.AddRange(lineItems);

            finances ??= Finances.From(_lineItems.ToArray());
            _orderable = Orderable.From(finances, state);
        }

        public static Result<Order, Error> From(
            Id customerId,
            List<Id> customerIds,
            OrderState state = OrderState.AwaitingConfirmation,
            params LineItem[] lineItems
        )
        {
            if (customerId is null)
                return Required(nameof(customerId));

            if (customerIds.All(x => x != customerId))
                return ErrorExtensions.CustomerNotFound();

            return new Order(customerId, state, lineItems: lineItems);
        }

        #endregion

        #region Public Interface

        public Id CustomerId { get; }
        public Finances Finances => _orderable.Finances;
        public IReadOnlyCollection<LineItem> LineItems => _lineItems.AsReadOnly();
        public OrderState State => _orderable.State;

        #endregion

        #region IOrderable Implementation

        public Result<Error> ApplyPayment(Money value) => _orderable.ApplyPayment(value);
        public Result<Error> Cancel() => _orderable.Cancel();
        public Result<Error> Confirm() => _orderable.Confirm();
        public Result<Error> IssueRefund() => _orderable.IssueRefund();

        #endregion
    }
}
