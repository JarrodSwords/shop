using System.Collections.Generic;
using Jgs.Cqrs;
using Jgs.Functional.Explicit;
using Shop.Sales.Orders;
using Shop.Sales.Services;
using Shop.Shared;

namespace Shop.Api.Spec.Sales.Orders
{
    public class FromWebsite : WhenSubmittingAnOrder
    {
        private readonly ICommandHandler<SubmitOrderWebsite, Result<OrderSubmitted, Error>> _handler;
        private SubmitOrderWebsite _command;

        #region Creation

        public FromWebsite(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _handler = Resolve<ICommandHandler<SubmitOrderWebsite, Result<OrderSubmitted, Error>>>();
        }

        #endregion

        #region Protected Interface

        protected override void CreateSubmitOrderCommand()
        {
            _command = new SubmitOrderWebsite(
                "chase.elliott@hms.com",
                new List<LineItemDto>
                {
                    new("mlc-b-lun")
                }
            );
        }

        protected override OrderSubmitted HandleSubmitOrder() => _handler.Handle(_command).Value;

        #endregion
    }
}
