using FluentValidation;

namespace Shop.Sales
{
    public partial class Product
    {
        private class Validator : AbstractValidator<Product>
        {
            #region Creation

            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }

            #endregion
        }
    }
}
