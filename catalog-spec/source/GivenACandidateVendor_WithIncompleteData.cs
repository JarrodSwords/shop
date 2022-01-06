using FluentAssertions;
using Jgs.Functional;
using Xunit;

namespace Shop.Catalog.Spec
{
    public class GivenACandidateVendor_WithIncompleteData
    {
        public class WhenCreatingTheVendor
        {
            #region Core

            private readonly Result<Vendor> _result;

            public WhenCreatingTheVendor()
            {
                _result = new Vendor.Builder().Build();
            }

            #endregion

            #region Test Methods

            [Fact]
            public void ThenNameIsRequired()
            {
                _result.Message.Should().Contain("Name is required.");
            }

            [Fact]
            public void ThenSkuTokenIsRequired()
            {
                _result.Message.Should().Contain("Sku token is required.");
            }

            #endregion
        }
    }
}
