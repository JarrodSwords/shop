using System.Collections.Generic;
using FluentValidation;
using Jgs.Ddd;
using Jgs.Functional;

namespace Shop.Sales
{
    public class Order : Aggregate
    {
        private readonly List<LineItem> _lineItems = new();

        #region Creation

        private Order(IOrderBuilder builder)
        {
            CustomerId = builder.GetCustomerId();
            _lineItems.AddRange(builder.GetLineItems());
        }

        #endregion

        #region Public Interface

        public Id CustomerId { get; }
        public OrderDetails Details { get; }
        public IReadOnlyCollection<LineItem> LineItems => _lineItems.AsReadOnly();

        #endregion

        #region Static Interface

        public static Result<Order> From(IOrderBuilder builder)
        {
            var order = new Order(builder);
            var validationResult = new Validator().Validate(order);

            return validationResult.IsValid
                ? Result.Success(order)
                : Result.Failure<Order>(validationResult.ToString());
        }

        #endregion

        private class Validator : AbstractValidator<Order>
        {
            #region Creation

            public Validator()
            {
                RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Could not assign customer.");
                RuleFor(x => x.LineItems).NotEmpty().WithMessage("Cannot process empty order.");
            }

            #endregion
        }
    }
}
