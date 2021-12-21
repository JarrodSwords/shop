using System.Collections.Generic;
using System.Net.Http.Json;
using FluentAssertions;
using Shop.Sales.Services;
using Xunit;

namespace Shop.Api.Spec.Sales
{
    [Collection("storage")]
    public class GivenAReturningCustomer : WebApiFixture
    {
        #region Core

        public GivenAReturningCustomer(IntegrationTestingFactory<Startup> factory) : base(
            factory,
            "api/sales"
        )
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async void WhenSubmittingAnOrder_ThenTheCustomerIsNotSaved()
        {
            var williamByron = new CustomerDto("william.byron@hms.com");

            var candidateOrder = new SubmitOrder(
                williamByron,
                LunchBoxes: 1
            );

            await HttpClient.PostAsJsonAsync("orders", candidateOrder);
            await HttpClient.PostAsJsonAsync("orders", candidateOrder);

            var customers = await HttpClient.GetFromJsonAsync<IEnumerable<CustomerDto>>("customers");

            customers.Should().ContainSingle(x => x.Email == williamByron.Email);
        }

        #endregion
    }
}
