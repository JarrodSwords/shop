using FluentValidation;

namespace Shop.Catalog
{
    public partial class Vendor
    {
        private class Validator : AbstractValidator<Vendor>
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
