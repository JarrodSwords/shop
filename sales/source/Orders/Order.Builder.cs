using System.Collections.Generic;
using Jgs.Ddd;
using Jgs.Functional.Explicit;
using Shop.Shared;
using static Shop.Sales.Orders.ErrorExtensions;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public class Builder
        {
            private readonly List<Id> _customerIds = new();
            private readonly List<Orders.LineItem> _lineItems = new();
            private Id _customerId;

            #region Public Interface

            public Builder Add(Orders.LineItem lineItem)
            {
                _lineItems.Add(lineItem);
                return this;
            }

            public Result<Order, Error> Build()
            {
                var result = From(
                    _customerId,
                    _customerIds,
                    lineItems: _lineItems.ToArray()
                );

                return result.IsSuccess
                    ? result.Value
                    : CouldNotCreateOrder();
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
