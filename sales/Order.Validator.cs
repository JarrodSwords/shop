using FluentValidation;

namespace Shop.Sales
{
    public partial class Order
    {
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
