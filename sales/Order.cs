using System;
using FluentValidation;
using Jgs.Ddd;
using Jgs.Functional;

namespace Shop.Sales
{
    public class Order : Aggregate
    {
        #region Creation

        private Order(IOrderBuilder builder)
        {
            CustomerId = builder.GetCustomerId();
            Details = builder.GetDetails();
        }

        #endregion

        #region Public Interface

        public DateTime? CancellationDate { get; private set; }
        public Id CustomerId { get; }
        public OrderDetails Details { get; private set; }
        public bool IsAwaitingFulfillment { get; private set; }
        public bool IsAwaitingPayment { get; private set; }
        public bool IsCancelled { get; private set; }

        public Order Cancel()
        {
            IsCancelled = true;
            IsAwaitingFulfillment = false;
            IsAwaitingPayment = false;
            CancellationDate = DateTime.Now;
            return this;
        }

        public Order ConfirmDetails()
        {
            IsAwaitingPayment = true;
            return this;
        }

        public Order ConfirmPayment()
        {
            IsAwaitingFulfillment = true;
            IsAwaitingPayment = false;
            return this;
        }

        public Order Update(OrderDetails details)
        {
            Details = details;
            return this;
        }

        #endregion

        #region Static Interface

        public static Result<Order> From(IOrderBuilder builder)
        {
            var order = new Order(builder);
            var validation = new Validator().Validate(order);

            return validation.IsValid
                ? Result.Success(order)
                : Result.Failure<Order>(validation.ToString());
        }

        #endregion

        private class Validator : AbstractValidator<Order>
        {
            #region Creation

            public Validator()
            {
                RuleFor(x => x.CustomerId).NotEmpty();
            }

            #endregion
        }
    }
}
