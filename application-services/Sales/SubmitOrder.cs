using System;
using Jgs.Cqrs;
using Jgs.Ddd;
using Shop.Domain.Sales;

namespace Shop.ApplicationServices.Sales
{
    public record SubmitOrder(CustomerDto Customer, OrderDetailsDto Details) : ICommand, IOrderBuilder
    {
        #region Internal Interface

        internal Id CustomerId { get; set; }

        #endregion

        #region IOrderBuilder Implementation

        public Id GetCustomerId() => CustomerId;

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
                    var customer = Domain.Sales.Customer.From(command.Customer);
                    _uow.Customers.Create(customer);
                    command.CustomerId = customer.Id;
                }

                var id = _uow.Orders.Create(Order.From(command));

                _uow.Commit();

                return id;
            }

            #endregion
        }
    }
}
