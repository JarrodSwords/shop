﻿using System.Collections.Generic;
using FluentAssertions;
using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;
using Xunit;

namespace Shop.Sales.Spec
{
    public class GivenACandidateProduct_WithIncompleteInformation
    {
        public class WhenCreatingTheProduct
        {
            #region Core

            private readonly Result<Product> _result;

            public WhenCreatingTheProduct()
            {
                _result = Product.From(new IncompleteProduct());
            }

            #endregion

            #region Test Methods

            [Fact]
            public void WhenCreatingTheProduct_ThenResultIsFailure()
            {
                _result.IsFailure.Should().BeTrue();
            }

            #endregion

            private record IncompleteProduct : IProductBuilder
            {
                #region IProductBuilder Implementation

                public Description GetDescription() => default;
                public Name GetName() => default;
                public Money GetPrice() => default;
                public Sku GetSku() => default;

                #endregion
            }
        }
    }

    public class GivenACandidateOrder_WithIncompleteInformation
    {
        public class WhenCreatingTheOrder
        {
            #region Core

            private readonly Result<Order> _result;

            public WhenCreatingTheOrder()
            {
                _result = Order.From(new IncompleteSubmission());
            }

            #endregion

            #region Test Methods

            [Fact]
            public void ThenCustomerIdIsRequired()
            {
                _result.Message.Should().Contain("Could not assign customer.");
            }

            [Fact]
            public void ThenOneOrMoreLineItemsAreRequired()
            {
                _result.Message.Should().Contain("Cannot process empty order.");
            }

            [Fact]
            public void ThenResultIsFailure()
            {
                _result.IsFailure.Should().BeTrue();
            }

            #endregion

            private record IncompleteSubmission : IOrderBuilder
            {
                #region IOrderBuilder Implementation

                public Id GetCustomerId() => default;
                public IEnumerable<LineItem> GetLineItems() => new List<LineItem>();
                public Money GetTip() => default;

                #endregion
            }
        }
    }
}
