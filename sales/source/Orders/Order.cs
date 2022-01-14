using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;
using Jgs.Functional.Explicit;
using Shop.Shared;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public partial class Order : Aggregate
    {
        private readonly List<LineItem> _lineItems = new();
        private State _state;
        private OrderStatus _status;

        #region Creation

        private Order(
            Id customerId,
            OrderStatus status,
            Finances finances,
            params LineItem[] lineItems
        )
        {
            CustomerId = customerId;

            if (lineItems != null)
                _lineItems.AddRange(lineItems);

            Finances = finances ?? Finances.From(_lineItems.ToArray());
            Status = status;
        }

        public static Result<Order, Error> From(
            Id customerId,
            List<Id> customerIds,
            OrderStatus status = OrderStatus.AwaitingConfirmation,
            Finances finances = default,
            params LineItem[] lineItems
        )
        {
            if (customerId is null)
                return Required(nameof(customerId));

            if (customerIds.All(x => x != customerId))
                return ErrorExtensions.CustomerNotFound();

            return new Order(customerId, status, finances, lineItems);
        }

        #endregion

        #region Public Interface

        public Id CustomerId { get; }
        public Finances Finances { get; private set; }
        public IReadOnlyCollection<LineItem> LineItems => _lineItems.AsReadOnly();

        public OrderStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                _state = State.From(this);
            }
        }

        public Result<Error> ApplyPayment(Money value) => _state.ApplyPayment(value);
        public Result<Error> Cancel() => _state.Cancel();
        public Result<Error> Confirm() => _state.Confirm();
        public Result<Error> IssueRefund() => _state.IssueRefund();

        #endregion
    }
}
