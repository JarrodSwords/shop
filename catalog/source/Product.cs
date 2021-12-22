﻿using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;

namespace Shop.Catalog
{
    public partial class Product : Aggregate
    {
        #region Creation

        private Product(IProductBuilder builder)
        {
            Description = builder.GetDescription();
            Name = builder.GetName();
            Price = builder.GetPrice();
        }

        public static Result<Product> From(IProductBuilder builder)
        {
            var product = new Product(builder);
            var validator = new Validator().Validate(product);

            return validator.IsValid
                ? Result.Success(product)
                : Result.Failure<Product>(validator.ToString());
        }

        #endregion

        #region Public Interface

        public ProductCategory Category { get; set; }
        public Description Description { get; }
        public Name Name { get; }
        public Money Price { get; }
        public RecordName RecordName => Name.Value.Trim().Replace(' ', '-').ToLower();

        #endregion
    }
}
