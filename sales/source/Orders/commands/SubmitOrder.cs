using System.Linq;
using Jgs.Cqrs;
using Jgs.Functional.Explicit;
using Shop.Sales.Customers;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public record SubmitOrder(
        Email Email,
        Options Exclusions = default,
        ushort Baguettes = default,
        ushort CouplesBoxes = default,
        ushort DessertBoxes = default,
        ushort FamilyBoxes = default,
        ushort LunchBoxes = default,
        ushort PartyBoxes = default,
        ushort Strawberries = default,
        decimal Tip = default
    ) : ICommand
    {
        public class OrderBuilder : IOrderBuilder
        {
            private readonly Order.Builder _builder = new();
            private readonly IUnitOfWork _uow;
            private SubmitOrder _command;

            #region Creation

            public OrderBuilder(IUnitOfWork uow)
            {
                _uow = uow;
            }

            #endregion

            #region Public Interface

            public Result<Order, Error> Build() => _builder.Build();

            public OrderBuilder With(SubmitOrder command)
            {
                _command = command;
                return this;
            }

            #endregion

            #region Private Interface

            private void CreateLineItem(Quantity quantity, Sku sku)
            {
                if (quantity == 0)
                    return;

                var product = _uow.Products.Find(sku);
                var exclusions = product.Categories.HasFlag(ProductCategories.Box)
                    ? _command.Exclusions
                    : Options.None;

                for (var i = 0; i < quantity; i++)
                    _builder.Add(new(product.Price, product.Id, exclusions));
            }

            #endregion

            #region IOrderBuilder Implementation

            public void CreateLineItems()
            {
                var (_, _, baguettes, couplesBoxes, dessertBoxes, familyBoxes, lunchBoxes, partyBoxes, strawberries, _
                    ) = _command;

                CreateLineItem(baguettes, "mlc-s-b");
                CreateLineItem(couplesBoxes, "mlc-b-cpl");
                CreateLineItem(dessertBoxes, "mlc-bd-dst");
                CreateLineItem(familyBoxes, "mlc-b-fam");
                CreateLineItem(lunchBoxes, "mlc-b-lun");
                CreateLineItem(partyBoxes, "mlc-b-pty");
                CreateLineItem(strawberries, $"mlc-ds-stw-{strawberries}");
            }

            public void FetchCustomers()
            {
                var customers = _uow.Customers.Fetch();
                var customerIds = customers.Select(x => x.Id).ToList();

                _builder.With(customerIds);
            }

            public void FindCustomer()
            {
                var email = _command.Email;

                if (_uow.Customers.Exists(_command.Email))
                {
                    _builder.With(_uow.Customers.Find(email).Id);
                }
                else
                {
                    var customer = Customer.From(email);

                    _uow.Customers.Create(customer);
                    _uow.Commit();

                    _builder.With(customer.Id);
                }
            }

            #endregion
        }
    }
}
