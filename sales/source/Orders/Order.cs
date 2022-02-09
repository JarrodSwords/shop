﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Jgs.Ddd;
using Jgs.Functional.Explicit;
using Shop.Shared;
using static Shop.Sales.Orders.ErrorExtensions;
using static Shop.Shared.Error;

namespace Shop.Sales.Orders
{
    public partial class Order : Aggregate
    {
        private readonly ObservableCollection<LineItem> _lineItems;
        private State _state;
        private OrderStatus _status;

        #region Creation

        private Order(
            Id customerId,
            OrderStatus status,
            Finances finances,
            params Orders.LineItem[] lineItems
        )
        {
            _lineItems = new();
            _lineItems.CollectionChanged += LineItemsChanged;

            CustomerId = customerId;
            Finances = finances ?? Finances.Default;
            Status = status;

            if (lineItems == null)
                return;

            foreach (var i in lineItems)
                _lineItems.Add(i);
        }

        public static Result<Order, Error> From(
            Id customerId,
            List<Id> customerIds,
            OrderStatus status = OrderStatus.Pending,
            Finances finances = default,
            params Orders.LineItem[] lineItems
        )
        {
            if (customerId is null)
                return Required(nameof(customerId));

            if (customerIds.All(x => x != customerId))
                return CustomerNotFound();

            return new Order(customerId, status, finances, lineItems);
        }

        #endregion

        #region Public Interface

        public Id CustomerId { get; }
        public Finances Finances { get; private set; }
        public bool HasLineItems => _lineItems.Count > 0;
        public IReadOnlyCollection<Orders.LineItem> LineItems => _lineItems.Select(x => x.Value).ToList().AsReadOnly();

        public OrderStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                _state = State.From(this);
                _state.EnterState();
            }
        }

        public Result<Error> Add(Orders.LineItem lineItem) => _state.Add(lineItem);
        public Result<Error> ApplyPayment(Money value) => _state.ApplyPayment(value);
        public Result<Error> Cancel() => _state.Cancel();
        public Result<Error> Confirm() => _state.Confirm();
        public Result<Error> IssueRefund() => _state.IssueRefund();
        public Result<Error> Remove(Id lineItemId) => _state.Remove(lineItemId);
        public Result<Error> Submit() => _state.Submit();

        #endregion

        #region Private Interface

        private void LineItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Finances = Finances.From(Finances, LineItems.ToArray());

            if (!HasLineItems)
                Status = OrderStatus.Canceled;
        }

        #endregion
    }
}
