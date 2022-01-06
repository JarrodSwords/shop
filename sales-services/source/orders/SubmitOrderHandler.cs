using System.Collections.Generic;
using Jgs.Cqrs;
using Jgs.Ddd;
using Jgs.Functional;
using Shop.Sales.Customers;
using Shop.Sales.Orders;

namespace Shop.Sales.Services
{
    public class SubmitOrderHandler : ICommandHandler<SubmitOrder, Result<OrderSubmitted>>
    {
        private readonly IUnitOfWork _uow;

        #region Creation

        public SubmitOrderHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        #endregion

        #region ICommandHandler<SubmitOrder,Result<OrderSubmitted>> Implementation

        public Result<OrderSubmitted> Handle(SubmitOrder command)
        {
            var email = command.Email;
            Id customerId;

            if (_uow.Customers.Exists(email))
            {
                customerId = _uow.Customers.Find(email).Id;
            }
            else
            {
                var customer = Customer.From(command.Email);
                _uow.Customers.Create(customer);
                customerId = customer.Id;
            }

            var lineItems = new List<LineItem>();

            if (command.Baguettes > 0)
                lineItems.Add(new(4, new(), command.Baguettes));

            if (command.CouplesBoxes > 0)
                lineItems.Add(new(39, new(), command.CouplesBoxes));

            if (command.DessertBoxes > 0)
                lineItems.Add(new(20, new(), command.DessertBoxes));

            if (command.FamilyBoxes > 0)
                lineItems.Add(new(69, new(), command.FamilyBoxes));

            if (command.LunchBoxes > 0)
                lineItems.Add(new(25, new(), command.LunchBoxes));

            if (command.PartyBoxes > 0)
                lineItems.Add(new(99, new(), command.PartyBoxes));

            var createOrderResult = new Order.Builder()
                .With(customerId)
                .With(lineItems)
                .With(command.Tip)
                .Build();

            if (createOrderResult.IsFailure)
                return Result.Failure<OrderSubmitted>("Order submission failed.");

            _uow.Orders.Create(createOrderResult.Value);
            _uow.Commit();

            return Result.Success(new OrderSubmitted(createOrderResult.Value.Id));
        }

        #endregion
    }
}
