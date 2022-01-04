using System;
using Shop.Catalog;
using Shop.Shared;

namespace Shop.Seeder
{
    public class ProductBuilder : IProductBuilder
    {
        private readonly Product.Builder _builder = new();
        private ProductCategories _categories;
        private Token _skuToken;

        #region Public Interface

        public Product Build() => _builder.Build().Value;

        public ProductBuilder With(CandidateProduct candidate)
        {
            var (name, skuToken, categories, description, size) = candidate;

            _builder
                .With(name)
                .With(categories)
                .With(description)
                .With(size)
                .With(Vendor.ManyLoves.Id);

            _categories = categories;
            _skuToken = skuToken;

            return this;
        }

        #endregion

        #region IProductBuilder Implementation

        public IProductBuilder FindVendor() => throw new NotSupportedException();

        public IProductBuilder GenerateSku()
        {
            var sku = Product.GenerateSku(
                Vendor.ManyLoves.SkuToken,
                _categories.GetToken(),
                _skuToken
            );

            _builder.With(sku);

            return this;
        }

        #endregion
    }
}
