using FluentAssertions;
using Jgs.Ddd;
using Jgs.Functional;
using Xunit;

namespace Shop.Sales.Spec
{
    public class GivenACandidateOrder_WithCompleteInformation
    {
        public class WhenCreatingTheOrder
        {
            #region Core

            private readonly CandidateOrder _candidateOrder;
            private readonly Order _order;
            private readonly Result<Order> _result;

            public WhenCreatingTheOrder()
            {
                _candidateOrder = new CandidateOrder();
                _result = Order.From(_candidateOrder);
                _order = _result.Value;
            }

            #endregion

            #region Test Methods

            [Fact]
            public void ThenCustomerIdIsAssigned()
            {
                _order.CustomerId.Should().Be(_candidateOrder.GetCustomerId());
            }

            [Fact]
            public void ThenResultIsSuccess()
            {
                _result.IsSuccess.Should().BeTrue();
            }

            #endregion

            private record CandidateOrder : IOrderBuilder
            {
                private readonly Id _customerId;

                #region Creation

                public CandidateOrder(Id customerId = default)
                {
                    _customerId = customerId ?? new Id();
                }

                #endregion

                #region IOrderBuilder Implementation

                public Id GetCustomerId() => _customerId;

                #endregion
            }
        }
    }
}
