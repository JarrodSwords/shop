using System;
using Jgs.Cqrs;
using Shop.Domain.Sales;

namespace Shop.ApplicationServices.Sales
{
    public record SubmitOrder(CustomerDto Customer, OrderDetailsDto Details) : ICommand, IOrderBuilder
    {
        #region IOrderBuilder Implementation

        public Customer GetCustomer() =>
            new(
                Customer.Email,
                Customer.FirstName,
                Customer.LastName
            );

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

            public Guid Handle(SubmitOrder command) => _uow.Orders.Create(Order.From(command));

            #endregion
        }
    }
}
