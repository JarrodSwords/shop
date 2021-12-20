using System;
using System.Collections.Generic;
using Jgs.Cqrs;
using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales.Services
{
    public record SubmitOrder(CustomerDto Customer, OrderDetailsDto Details) : ICommand, IOrderBuilder
    {
        #region Public Interface

        public OrderDetails GetDetails() =>
            new(
                Details.Baguettes,
                Details.CouplesBoxes,
                Details.DessertBoxes,
                Details.FamilyBoxes,
                Details.IsGift,
                Details.IsSpecialOccasion,
                Details.LunchBoxes,
                Details.PartyBoxes,
                Details.Strawberries
            );

        #endregion

        #region Internal Interface

        internal Id CustomerId { get; set; }

        #endregion

        #region IOrderBuilder Implementation

        public Id GetCustomerId() => CustomerId;
        public IEnumerable<LineItem> GetLineItems() => throw new NotImplementedException();
        public Money GetTip() => throw new NotImplementedException();

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
