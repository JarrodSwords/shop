using System;
using System.Collections.Generic;
using Jgs.Cqrs;
using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales.Services
{
    public record RegisterProduct(
        string Description,
        string Name,
        decimal Price
    ) : ICommand, IProductBuilder
    {
        #region IProductBuilder Implementation

        public Description GetDescription() => Description;
        public Name GetName() => Name;
        public Money GetPrice() => Price;

        #endregion

        public class Handler : ICommandHandler<RegisterProduct, ProductDto>
        {
            private readonly IUnitOfWork _uow;

            #region Creation

            public Handler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            #endregion

            #region ICommandHandler<RegisterProduct,ProductDto> Implementation

            public ProductDto Handle(RegisterProduct command)
            {
                var product = Product.From(command).Value;

                _uow.Products.Create(product);
                _uow.Commit();

                return ProductDto.From(product);
            }

            #endregion
        }
    }

    public record SubmitOrder(
        CustomerDto Customer,
        ushort Baguettes = default,
        ushort CouplesBoxes = default,
        ushort DessertBoxes = default,
        ushort FamilyBoxes = default,
        ushort LunchBoxes = default,
        ushort PartyBoxes = default,
        decimal Tip = default
    ) : ICommand, IOrderBuilder
    {
        #region Internal Interface

        internal Id CustomerId { get; set; }

        #endregion

        #region IOrderBuilder Implementation

        public Id GetCustomerId() => CustomerId;

        public IEnumerable<LineItem> GetLineItems()
        {
            var lineItems = new List<LineItem>();

            if (Baguettes > 0)
                lineItems.Add(new(4, new(), Baguettes));

            if (CouplesBoxes > 0)
                lineItems.Add(new(39, new(), CouplesBoxes));

            if (DessertBoxes > 0)
                lineItems.Add(new(20, new(), DessertBoxes));

            if (FamilyBoxes > 0)
                lineItems.Add(new(69, new(), FamilyBoxes));

            if (LunchBoxes > 0)
                lineItems.Add(new(25, new(), LunchBoxes));

            if (PartyBoxes > 0)
                lineItems.Add(new(99, new(), PartyBoxes));

            return lineItems;
        }

        public Money GetTip() => Tip;

        #endregion

        public class Handler : ICommandHandler<SubmitOrder, Guid>
        {
            private readonly IUnitOfWork _uow;

            #region Creation

            public Handler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            #endregion

            #region ICommandHandler<SubmitOrder,Guid> Implementation

            public Guid Handle(SubmitOrder command)
            {
                var email = command.Customer.Email;

                if (_uow.Customers.Exists(email))
                {
                    command.CustomerId = _uow.Customers.Find(email).Id;
                }
                else
                {
                    var customer = Sales.Customer.From(command.Customer);
                    _uow.Customers.Create(customer);
                    command.CustomerId = customer.Id;
                }

                var createOrderResult = Order.From(command);

                if (createOrderResult.IsFailure)
                    return Guid.Empty;

                var id = _uow.Orders.Create(createOrderResult.Value);

                _uow.Commit();

                return id;
            }

            #endregion
        }
    }
}
