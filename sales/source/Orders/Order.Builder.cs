using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;
using Jgs.Functional.Explicit;
using Shop.Sales.Customers;
using Shop.Shared;
using static Shop.Sales.Orders.ErrorExtensions;

namespace Shop.Sales.Orders
{
    public partial class Order
    {
        public class Builder
        {
            private readonly List<LineItem> _lineItems = new();
            private readonly IUnitOfWork _uow;
            private Email _email;

            #region Creation

            public Builder(IUnitOfWork uow)
            {
                _uow = uow;
            }

            #endregion

            #region Public Interface

            public Result<Order, Error> Build()
            {
                var customerId = FindCustomer();
                var customerIds = FetchCustomers().ToList();

                var result = From(
                    customerId,
                    customerIds,
                    lineItems: _lineItems.ToArray()
                );

                return result.IsSuccess
                    ? result.Value
                    : CouldNotCreateOrder();
            }

            public Builder CreateLineItem(Sku sku, Options exclusions = Options.None, Quantity quantity = default)
            {
                quantity ??= 1;

                if (quantity == 0)
                    return this;

                var product = _uow.Products.Find(sku);

                for (var i = 0; i < quantity; i++)
                    _lineItems.Add(new(product.Price, product.Id, exclusions));

                return this;
            }

            public Builder With(Email email)
            {
                _email = email;
                return this;
            }

            #endregion

            #region Private Interface

            private IEnumerable<Id> FetchCustomers() => _uow.Customers.Fetch().Select(x => x.Id);

            private Id FindCustomer()
            {
                if (_uow.Customers.Exists(_email))
                    return _uow.Customers.Find(_email).Id;

                var customer = Customer.From(_email);

                _uow.Customers.Create(customer);
                _uow.Commit();

                return customer.Id;
            }

            #endregion
        }
    }
}
