using System.Collections.Generic;
using Jgs.Ddd;
using Jgs.Functional;
using static Jgs.Functional.Result;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public class Builder
        {
            private readonly List<Id> _customerIds = new();
            private readonly List<LineItem> _lineItems = new();
            private Id _customerId;

            #region Public Interface

            public Builder Add(LineItem lineItem)
            {
                _lineItems.Add(lineItem);
                return this;
            }

            public Result<Order> Build()
            {
                var result = From(
                    _customerId,
                    _customerIds,
                    lineItems: _lineItems.ToArray()
                );

                return result.IsSuccess
                    ? Success(result.Value)
                    : Failure<Order>("Could not construct");
            }

            public Builder With(Id customerId)
            {
                _customerId = customerId;
                return this;
            }

            public Builder With(List<Id> customerIds)
            {
                _customerIds.AddRange(customerIds);
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
                _builder.FetchCustomers();
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
