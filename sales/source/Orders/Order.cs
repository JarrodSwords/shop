using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public partial class Order : Aggregate
    {
        private readonly List<LineItem> _lineItems = new();

        #region Creation

        private Order(
            Id customerId,
            IEnumerable<LineItem> lineItems,
            Money tip
        )
        {
            CustomerId = customerId;
            _lineItems.AddRange(lineItems);
            Tip = tip;
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
