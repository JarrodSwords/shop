﻿using FluentValidation;

namespace Shop.Catalog
{
    public partial class Product
    {
        private class Validator : AbstractValidator<Product>
        {
            #region Creation

            public Validator()
            {
                RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
                RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.");
                RuleFor(x => x.Size).NotEmpty().WithMessage("Size is required.");
            }

            #endregion
        }
    }
}
