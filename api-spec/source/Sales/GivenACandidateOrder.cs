﻿using System;
using System.Net.Http.Json;
using FluentAssertions;
using Shop.Sales.Services;
using Xunit;

namespace Shop.Api.Spec.Sales
{
    [Collection("storage")]
    public class GivenACandidateOrder : WebApiFixture
    {
        #region Core

        public GivenACandidateOrder(IntegrationTestingFactory<Startup> factory) : base(factory, "api/sales")
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async void WhenSubmittingAnOrder_ThenOrderIsRetrievable()
        {
            var candidateOrder = new SubmitOrder(
                ObjectProvider.GetJonDoe(),
                new OrderDetailsDto(LunchBoxes: 1)
            );

            var orderId = await HttpClient
                .PostAsJsonAsync("orders", candidateOrder)
                .Result.Content.ReadFromJsonAsync<Guid>();

            var order = await HttpClient.GetFromJsonAsync<OrderDto>($"orders/{orderId}");

            order.Email.Should().Be("jon.doe@gmail.com");
        }

        #endregion
    }
}