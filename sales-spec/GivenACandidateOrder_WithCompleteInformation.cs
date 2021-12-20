﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;
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

            [Theory]
            [InlineData(1, 1, 0, 0, 1)]
            [InlineData(0, 0, 1, 1, 1)]
            [InlineData(1, 2, 3, 4, 14)]
            [InlineData(0.99, 1, 9, 1, 9.99)]
            public void ThenSubtotalIsAggregateOfLineItems(
                decimal p1,
                ushort q1,
                decimal p2,
                ushort q2,
                decimal expectedSubtotal
            )
            {
                var candidateOrder = new CandidateOrder(
                    null,
                    null,
                    new LineItem(p1, new(), q1),
                    new LineItem(p2, new(), q2)
                );

                var order = Order.From(candidateOrder).Value;

                order.Subtotal.Should().Be((Money) expectedSubtotal);
            }

            [Theory]
            [InlineData(0)]
            [InlineData(0.99)]
            [InlineData(1)]
            public void ThenTotalIsSubtotalPlusTip(decimal tip)
            {
                var candidateOrder = new CandidateOrder(tip: tip);

                var order = Order.From(candidateOrder).Value;

                order.Total.Should().Be(order.Subtotal + tip);
            }

            #endregion

            private record CandidateOrder : IOrderBuilder
            {
                private readonly Id _customerId;
                private readonly List<LineItem> _lineItems;
                private readonly Money _tip;

                #region Creation

                public CandidateOrder(
                    Id customerId = default,
                    Money tip = default,
                    params LineItem[] lineItems
                )
                {
                    _customerId = customerId ?? new Id();
                    _tip = tip ?? Money.Zero;
                    _lineItems = lineItems.Length > 0
                        ? lineItems.ToList()
                        : new()
                        {
                            new LineItem(1m, new(), 2),
                            new LineItem(3m, new(), 4)
                        };
                }

                #endregion

                #region IOrderBuilder Implementation

                public Id GetCustomerId() => _customerId;
                public IEnumerable<LineItem> GetLineItems() => _lineItems;
                public Money GetTip() => _tip;

                #endregion
            }
        }
    }
}
