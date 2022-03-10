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
    public abstract class FromGoogleForm : WhenSubmittingAnOrder
    {
        protected readonly ICommandHandler<SubmitOrderGoogleForm, Result<OrderSubmitted, Error>> Handler;
        private SubmitOrderGoogleForm _command;

        #region Creation

        protected FromGoogleForm(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            Handler = Resolve<ICommandHandler<SubmitOrderGoogleForm, Result<OrderSubmitted, Error>>>();
        }

        #endregion

        #region Protected Interface

        protected override void CreateSubmitOrderCommand()
        {
            _command = new SubmitOrderGoogleForm(
                "chase.elliott@hms.com",
                LunchBoxes: 1
            );
        }

        protected override OrderSubmitted HandleSubmitOrder() => Handler.Handle(_command).Value;

        #endregion

        public class WithAnUnregisteredCustomer : FromGoogleForm
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

                Handler.Handle(candidateOrder);
                var customerExists = _uow.Customers.Exists(email);

                customerExists.Should().BeTrue();
            }

            #endregion
        }

        public class WithARegisteredCustomer : FromGoogleForm
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

                Handler.Handle(candidateOrder);
                Handler.Handle(candidateOrder);

                var customers = _fetchCustomers.Handle(new());

                customers.Should().ContainSingle(x => x.Email == email);
            }

            #endregion
        }
    }
}
