using System.Collections.Generic;
using FluentAssertions;
using Jgs.Cqrs;
using Jgs.Functional.Explicit;
using Shop.Sales;
using Shop.Sales.Orders;
using Shop.Sales.Services;
using Shop.Shared;
using Xunit;

namespace Shop.Api.Spec.Sales.Orders
{
    [Collection("storage")]
    public abstract class WhenSubmittingAnOrder_FromGoogleForm : ApplicationFixture
    {
        #region Core

        private readonly IQueryHandler<FindOrder, OrderDto> _findOrder;
        protected readonly ICommandHandler<SubmitOrderGoogleForm, Result<OrderSubmitted, Error>> SubmitOrder;

        protected WhenSubmittingAnOrder_FromGoogleForm(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _findOrder = Resolve<IQueryHandler<FindOrder, OrderDto>>();
            SubmitOrder = Resolve<ICommandHandler<SubmitOrderGoogleForm, Result<OrderSubmitted, Error>>>();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void ThenTheOrderIsSaved()
        {
            var candidateOrder = new SubmitOrderGoogleForm(
                "chase.elliott@hms.com",
                LunchBoxes: 1
            );

            var orderSubmitted = SubmitOrder.Handle(candidateOrder).Value;
            var order = _findOrder.Handle(orderSubmitted.Id);

            order.Should().NotBeNull();
        }

        #endregion

        public class WithARegisteredCustomer : WhenSubmittingAnOrder_FromGoogleForm
        {
            #region Core

            private readonly IQueryHandler<FetchCustomers, IEnumerable<CustomerDto>> _fetchCustomers;

            public WithARegisteredCustomer(IntegrationTestingFactory<Startup> factory) : base(factory)
            {
                _fetchCustomers = Resolve<IQueryHandler<FetchCustomers, IEnumerable<CustomerDto>>>();
            }

            #endregion

            #region Test Methods

            [Theory]
            [InlineData("william.byron@hms.com")]
            public void ThenTheCustomerIsNotRegisteredTwice(string email)
            {
                var candidateOrder = new SubmitOrderGoogleForm(
                    email,
                    LunchBoxes: 1
                );

                SubmitOrder.Handle(candidateOrder);
                SubmitOrder.Handle(candidateOrder);

                var customers = _fetchCustomers.Handle(new());

                customers.Should().ContainSingle(x => x.Email == email);
            }

            #endregion
        }

        public class WithAnUnregisteredCustomer : WhenSubmittingAnOrder_FromGoogleForm
        {
            #region Core

            private readonly IUnitOfWork _uow;

            public WithAnUnregisteredCustomer(IntegrationTestingFactory<Startup> factory) : base(factory)
            {
                _uow = Resolve<IUnitOfWork>();
            }

            #endregion

            #region Test Methods

            [Theory]
            [InlineData("kyle.larson@hms.com")]
            public void ThenTheCustomerIsRegistered(string email)
            {
                var candidateOrder = new SubmitOrderGoogleForm(
                    email,
                    LunchBoxes: 1
                );

                SubmitOrder.Handle(candidateOrder);
                var customerExists = _uow.Customers.Exists(email);

                customerExists.Should().BeTrue();
            }

            #endregion
        }
    }
}
