using System;
using FluentAssertions;
using Jgs.Ddd;
using Xunit;

namespace Shop.Sales.Spec.GivenACandidateOrder
{
    public class WhenCreatingOrder
    {
        #region Core

        private readonly CandidateOrderDto _candidateOrder = new();
        private readonly Order _order;

        public WhenCreatingOrder()
        {
            _order = Order.From(_candidateOrder);
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ThenDetailsAreSet()
        {
            _order.Details.Should().Be(_candidateOrder.GetDetails());
        }

        #endregion

        public record CandidateOrderDto : IOrderBuilder
        {
            #region IOrderBuilder Implementation

            public Id GetCustomerId() => Guid.NewGuid();

            public OrderDetails GetDetails() => new(familyBoxes: 1);

            #endregion
        }
    }
}
