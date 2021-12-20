using System.Collections.Generic;
using FluentAssertions;
using Jgs.Ddd;
using Jgs.Functional;
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
                _result = Order.From(new IncompleteSubmission());
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

            private record IncompleteSubmission : IOrderBuilder
            {
                #region IOrderBuilder Implementation

                public Id GetCustomerId() => default;
                public IEnumerable<LineItem> GetLineItems() => new List<LineItem>();

                #endregion
            }
        }
    }
}
