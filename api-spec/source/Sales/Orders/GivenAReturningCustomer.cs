﻿using System.Collections.Generic;
using FluentAssertions;
using Jgs.Cqrs;
using Jgs.Functional.Explicit;
using Shop.Sales.Orders;
using Shop.Sales.Services;
using Shop.Shared;
using Xunit;

namespace Shop.Api.Spec.Sales.Orders
{
    [Collection("storage")]
    public class GivenAReturningCustomer : ApplicationFixture
    {
        #region Core

        private readonly IQueryHandler<FetchCustomers, IEnumerable<CustomerDto>> _fetchCustomers;
        private readonly ICommandHandler<SubmitOrder, Result<OrderSubmitted, Error>> _submitOrder;

        public GivenAReturningCustomer(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _fetchCustomers = Resolve<IQueryHandler<FetchCustomers, IEnumerable<CustomerDto>>>();
            _submitOrder = Resolve<ICommandHandler<SubmitOrder, Result<OrderSubmitted, Error>>>();
        }

        #endregion

        #region Test Methods

        [Theory]
        [InlineData("william.byron@hms.com")]
        public void WhenSubmittingAnOrder_ThenTheCustomerIsNotSaved(string email)
        {
            var candidateOrder = new SubmitOrder(
                email,
                LunchBoxes: 1
            );

            _submitOrder.Handle(candidateOrder);
            _submitOrder.Handle(candidateOrder);

            var customers = _fetchCustomers.Handle(new());

            customers.Should().ContainSingle(x => x.Email == email);
        }

        #endregion
    }
}
