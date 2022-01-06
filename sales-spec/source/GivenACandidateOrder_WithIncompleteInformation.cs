using FluentAssertions;
using Jgs.Functional;
using Shop.Sales.Orders;
using Xunit;

namespace Shop.Sales.Spec
{
    public class GivenACandidateOrder_WithIncompleteInformation
    {
        public class WhenCreatingTheOrder
        {
            #region Core

            private readonly Result<Order> _result;

            public WhenCreatingTheOrder()
            {
                _result = new Order.Builder().Build();
            }

            #endregion

            #region Test Methods

            [Fact]
            public void ThenCustomerIdIsRequired()
            {
                _result.Message.Should().Contain("Could not assign customer.");
            }

            [Fact]
            public void ThenOneOrMoreLineItemsAreRequired()
            {
                _result.Message.Should().Contain("Cannot process empty order.");
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
