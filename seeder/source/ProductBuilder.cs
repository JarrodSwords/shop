using System;
using Shop.Catalog;

namespace Shop.Seeder
{
    public class ProductBuilder : IProductBuilder
    {
        private readonly Product.Builder _builder = new();
        private CandidateProduct _candidate;

        #region Public Interface

        public Product Build() => _builder.Build().Value;

        public ProductBuilder With(CandidateProduct candidate)
        {
            _candidate = candidate;

            var (name, _, categories, description, size) = candidate;

            _builder
                .With(name)
                .With(categories)
                .With(description)
                .With(size)
                .With(Vendor.ManyLoves.Id);

            return this;
        }

        #endregion

        #region IProductBuilder Implementation

        public IProductBuilder FindVendor() => throw new NotSupportedException();

        public IProductBuilder GenerateSku()
        {
            var sku = Product.GenerateSku(
                Vendor.ManyLoves.SkuToken,
                _candidate.Categories.GetToken(),
                _candidate.SkuToken,
                _candidate.Size
            );

            _builder.With(sku);

            return this;
        }

        #endregion
    }
}
