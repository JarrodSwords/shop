﻿using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;
using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public partial class Order : Aggregate
    {
        private readonly List<LineItem> _lineItems = new();

        #region Creation

        public Order(
            Id customerId,
            IEnumerable<LineItem> lineItems,
            Money tip = default
        )
        {
            CustomerId = customerId;
            _lineItems.AddRange(lineItems);
            Tip = tip ?? Money.Zero;
        }

        public static Result<Order, Error> From(
            Id customerId,
            List<Id> customerIds
        )
        {
            if (customerId is null)
                return Error.Required(nameof(customerId));

            if (customerIds.All(x => x != customerId))
                return ErrorExtensions.CustomerNotFound();

            return new Order(customerId, null);
        }

        #endregion

        #region Public Interface

        public Id CustomerId { get; }
        public IReadOnlyCollection<LineItem> LineItems => _lineItems.AsReadOnly();
        public Money Subtotal => _lineItems.Aggregate(Money.Zero, (current, li) => current + li.Total);
        public Money Tip { get; }
        public Money Total => Subtotal + Tip;

        #endregion
    }
}
