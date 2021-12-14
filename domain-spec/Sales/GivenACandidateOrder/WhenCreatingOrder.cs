using FluentAssertions;
using Shop.Domain.Sales;
using Xunit;

namespace Shop.Domain.Spec.Sales.GivenACandidateOrder
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
        public void ThenCustomerIsSet()
        {
            _order.Customer.Should().NotBeNull();
        }

        #endregion

        public record CandidateOrderDto : IOrderBuilder
        {
            #region IOrderBuilder Implementation

            public Customer GetCustomer() => ObjectProvider.CreateJohnDoe();

            #endregion
        }
    }
}
