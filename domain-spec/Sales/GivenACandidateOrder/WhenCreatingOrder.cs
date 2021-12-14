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
            _order.Customer.Should().Be(_candidateOrder.GetCustomer());
        }

        [Fact]
        public void ThenDetailsAreSet()
        {
            _order.Details.Should().Be(_candidateOrder.GetDetails());
        }

        #endregion

        public record CandidateOrderDto : IOrderBuilder
        {
            private Customer _customer;

            #region IOrderBuilder Implementation

            public Customer GetCustomer() => _customer ??= ObjectProvider.CreateJohnDoe();
            public OrderDetails GetDetails() => new(familyBoxes: 1);

            #endregion
        }
    }
}
