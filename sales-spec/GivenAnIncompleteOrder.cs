using FluentAssertions;
using Jgs.Ddd;
using Jgs.Functional;
using Xunit;

namespace Shop.Sales.Spec
{
    public class GivenAnIncompleteCandidateOrder
    {
        internal record IncompleteOrder : IOrderBuilder
        {
            #region IOrderBuilder Implementation

            public Id GetCustomerId() => default;
            public OrderDetails GetDetails() => default;

            #endregion
        }

        public class WhenCreatingTheOrder
        {
            #region Core

            private readonly Result<Order> _result;

            public WhenCreatingTheOrder()
            {
                _result = Order.From(new IncompleteOrder());
            }

            #endregion

            #region Test Methods

            [Fact]
            public void ThenCustomerIdIsRequired()
            {
                _result.Message.Should().Contain(@"Could not assign customer.");
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
