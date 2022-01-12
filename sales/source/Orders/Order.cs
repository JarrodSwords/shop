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
        private readonly State _state;

        #region Creation

        private Order(
            Id customerId,
            OrderStatus status,
            Finances finances = default,
            params LineItem[] lineItems
        )
        {
            CustomerId = customerId;

            if (lineItems != null)
                _lineItems.AddRange(lineItems);

            finances ??= Finances.From(_lineItems.ToArray());
            _state = State.From(finances, status);
        }

        public static Result<Order, Error> From(
            Id customerId,
            List<Id> customerIds,
            OrderStatus status = OrderStatus.AwaitingConfirmation,
            params LineItem[] lineItems
        )
        {
            if (customerId is null)
                return Required(nameof(customerId));

            if (customerIds.All(x => x != customerId))
                return ErrorExtensions.CustomerNotFound();

            return new Order(customerId, status, lineItems: lineItems);
        }

        #endregion

        #region Public Interface

        public Id CustomerId { get; }
        public Finances Finances => _state.Finances;
        public IReadOnlyCollection<LineItem> LineItems => _lineItems.AsReadOnly();
        public OrderStatus Status => _state.Status;

        #endregion

        #region IOrderable Implementation

        public Result<Error> ApplyPayment(Money value) => _state.ApplyPayment(value);
        public Result<Error> Cancel() => _state.Cancel();
        public Result<Error> Confirm() => _state.Confirm();
        public Result<Error> IssueRefund() => _state.IssueRefund();

        #endregion
    }
}
