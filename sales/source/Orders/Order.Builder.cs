using System.Collections.Generic;
using Jgs.Ddd;
using Jgs.Functional;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public class Builder
        {
            private readonly List<LineItem> _lineItems = new();
            private Id _customerId;
            private Money _tip;

            #region Public Interface

            public Builder Add(LineItem lineItem)
            {
                _lineItems.Add(lineItem);
                return this;
            }

            public Result<Order> Build()
            {
                var order = new Order(_customerId, _lineItems, OrderStates.AwaitingPayment, _tip);
                var validationResult = new Validator().Validate(order);

                return validationResult.IsValid
                    ? Result.Success(order)
                    : Result.Failure<Order>(validationResult.ToString());
            }

            public Builder With(Id customerId)
            {
                _customerId = customerId;
                return this;
            }

            public Builder With(Money tip)
            {
                _tip = tip;
                return this;
            }

            #endregion
        }

        public class Director
        {
            private IOrderBuilder _builder;

            #region Public Interface

            public Director ConfigureSubmitOrder()
            {
                _builder.FindCustomer();
                _builder.CreateLineItems();
                return this;
            }

            public Director With(IOrderBuilder builder)
            {
                _builder = builder;
                return this;
            }

            #endregion
        }
    }
}
