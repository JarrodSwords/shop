using System;
using System.Net.Http.Json;
using FluentAssertions;
using Shop.Sales.Services;
using Xunit;

namespace Shop.Api.Spec.Sales
{
    [Collection("storage")]
    public class GivenANewCustomer : WebApiFixture
    {
        #region Core

        public GivenANewCustomer(IntegrationTestingFactory<Startup> factory) : base(
            factory,
            "api/sales"
        )
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async void WhenSubmittingAnOrder_ThenTheCustomerIsSaved()
        {
            var kyleLarson = new CustomerDto("kyle.larson@hms.com");

            var candidateOrder = new SubmitOrder(
                kyleLarson,
                LunchBoxes: 1
            );

            await HttpClient.PostAsJsonAsync("orders", candidateOrder);

            var customer = await HttpClient.GetFromJsonAsync<CustomerDto>($@"customers/{kyleLarson.Email}");

            customer.Should().Be(kyleLarson);
        }

        [Fact]
        public async void WhenSubmittingAnOrder_ThenTheOrderIsSaved()
        {
            var chaseElliott = new CustomerDto("chase.elliott@hms.com");

            var candidateOrder = new SubmitOrder(
                chaseElliott,
                LunchBoxes: 1
            );

            var orderId = await HttpClient
                .PostAsJsonAsync("orders", candidateOrder)
                .Result.Content.ReadFromJsonAsync<Guid>();

            var order = await HttpClient.GetFromJsonAsync<OrderDto>($"orders/{orderId}");

            order.Should().NotBeNull();
        }

        #endregion
    }
}
