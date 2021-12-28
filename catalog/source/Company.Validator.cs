using FluentValidation;

namespace Shop.Catalog
{
    public partial class Company
    {
        private class Validator : AbstractValidator<Company>
        {
            #region Creation

            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
                RuleFor(x => x.SkuToken).NotEmpty().WithMessage("Sku token is required.");
            }

            #endregion
        }
    }
}
