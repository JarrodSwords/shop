using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;

namespace Shop.Sales
{
    public partial class Order : Aggregate
    {
        private readonly List<LineItem> _lineItems = new();

        #region Creation

        private Order(IOrderBuilder builder)
        {
            CustomerId = builder.GetCustomerId();
            _lineItems.AddRange(builder.GetLineItems());
            Tip = builder.GetTip();
        }

        public static Result<Order> From(IOrderBuilder builder)
        {
            var order = new Order(builder);
            var validationResult = new Validator().Validate(order);

            return validationResult.IsValid
                ? Result.Success(order)
                : Result.Failure<Order>(validationResult.ToString());
        }

        #endregion

        #region Public Interface

        public Id CustomerId { get; }
        public OrderDetails Details { get; }
        public IReadOnlyCollection<LineItem> LineItems => _lineItems.AsReadOnly();
        public Money Subtotal => _lineItems.Aggregate(Money.Zero, (current, li) => current + li.Total);
        public Money Tip { get; }
        public Money Total => Subtotal + Tip;

        #endregion
    }
}
