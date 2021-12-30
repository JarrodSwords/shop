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
            public void ThenCompanyIdIsRequired()
            {
                _result.Message.Should().Contain("Company is required.");
            }

            [Fact]
            public void ThenNameIsRequired()
            {
                _result.Message.Should().Contain("Name is required.");
            }

            [Fact]
            public void ThenResultIsFailure()
            {
                _result.IsFailure.Should().BeTrue();
            }

            #endregion

            private record IncompleteProduct : IProductBuilder
            {
                #region IProductBuilder Implementation

                public ProductCategories GetCategories() => default;
                public Company GetCompany() => default;
                public Description GetDescription() => default;
                public Name GetName() => default;
                public Size GetSize() => default;
                public Token GetSkuToken() => default;

                #endregion
            }
        }
    }
}
