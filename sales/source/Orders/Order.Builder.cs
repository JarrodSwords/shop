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
            private Id _customerId;
            private List<LineItem> _lineItems = new();
            private Money _tip;

            #region Public Interface

            public Result<Order> Build()
            {
                var order = new Order(_customerId, _lineItems, _tip);
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

            public Builder With(List<LineItem> lineItems)
            {
                _lineItems = lineItems;
                return this;
            }

            public Builder With(Money tip)
            {
                _tip = tip;
                return this;
            }

            #endregion
        }
    }
}
