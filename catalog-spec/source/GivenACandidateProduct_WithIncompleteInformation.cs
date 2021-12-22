using FluentAssertions;
using Jgs.Functional;
using Shop.Shared;
using Xunit;

namespace Shop.Catalog.Spec
{
    public class GivenACandidateProduct_WithIncompleteInformation
    {
        public class WhenCreatingTheProduct
        {
            #region Core

            private readonly Result<Product> _result;

            public WhenCreatingTheProduct()
            {
                _result = Product.From(new IncompleteProduct());
            }

            #endregion

            #region Test Methods

            [Fact]
            public void ThenCategoryIsRequired()
            {
                _result.Message.Should().Contain("Category is required.");
            }

            [Fact]
            public void ThenNameIsRequired()
            {
                _result.Message.Should().Contain("Name is required.");
            }

            [Fact]
            public void ThenPriceIsRequired()
            {
                _result.Message.Should().Contain("Price is required.");
            }

            [Fact]
            public void ThenResultIsFailure()
            {
                _result.IsFailure.Should().BeTrue();
            }

            [Fact]
            public void ThenSizeIsRequired()
            {
                _result.Message.Should().Contain("Size is required.");
            }

            #endregion

            private record IncompleteProduct : IProductBuilder
            {
                #region IProductBuilder Implementation

                public ProductCategory GetCategory() => default;
                public Description GetDescription() => default;
                public Name GetName() => default;
                public Money GetPrice() => default;
                public Size GetSize() => default;

                #endregion
            }
        }
    }
}
