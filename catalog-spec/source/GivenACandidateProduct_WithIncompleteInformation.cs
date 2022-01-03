using FluentAssertions;
using Jgs.Functional;
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
                _result = new Product.Builder().Build();
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
        }
    }
}
