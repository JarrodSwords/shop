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
        }

        #endregion

        #region Public Interface

        public Id CustomerId { get; }

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
            }

            #endregion
        }
    }
}
