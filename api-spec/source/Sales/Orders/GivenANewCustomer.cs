using FluentAssertions;
using Jgs.Cqrs;
using Jgs.Functional;
using Shop.Sales;
using Shop.Sales.Orders;
using Shop.Sales.Services;
using Xunit;

namespace Shop.Api.Spec.Sales.Orders
{
    [Collection("storage")]
    public class GivenANewCustomer : ApplicationFixture
    {
        #region Core

        private readonly IQueryHandler<FindOrder, OrderDto> _findOrder;
        private readonly ICommandHandler<SubmitOrder, Result<OrderSubmitted>> _submitOrder;
        private readonly IUnitOfWork _uow;

        public GivenANewCustomer(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _findOrder = Resolve<IQueryHandler<FindOrder, OrderDto>>();
            _submitOrder = Resolve<ICommandHandler<SubmitOrder, Result<OrderSubmitted>>>();
            _uow = Resolve<IUnitOfWork>();
        }

        #endregion

        #region Test Methods

        [Theory]
        [InlineData("kyle.larson@hms.com")]
        public void WhenSubmittingAnOrder_ThenTheCustomerIsSaved(string email)
        {
            var candidateOrder = new SubmitOrder(
                email,
                LunchBoxes: 1
            );

            _submitOrder.Handle(candidateOrder);
            var customerExists = _uow.Customers.Exists(email);

            customerExists.Should().BeTrue();
        }

        [Fact]
        public void WhenSubmittingAnOrder_ThenTheOrderIsSaved()
        {
            var candidateOrder = new SubmitOrder(
                "chase.elliott@hms.com",
                LunchBoxes: 1
            );

            var orderSubmitted = _submitOrder.Handle(candidateOrder).Value;
            var order = _findOrder.Handle(orderSubmitted.Id);

            order.Should().NotBeNull();
        }

        #endregion
    }
}
