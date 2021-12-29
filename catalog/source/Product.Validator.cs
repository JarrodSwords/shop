using FluentValidation;

namespace Shop.Catalog
{
    public partial class Product
    {
        private class Validator : AbstractValidator<Product>
        {
            #region Creation

            public Validator()
            {
                RuleFor(x => x.Categories).NotNull().WithMessage("Category is required.");
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            }

            #endregion
        }
    }
}
