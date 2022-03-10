using FluentAssertions;
using Jgs.Cqrs;
using Shop.Sales.Services;
using Xunit;

namespace Shop.Api.Spec.Sales.Orders
{
    [Collection("storage")]
    public abstract class WhenSubmittingAnOrder : ApplicationFixture
    {
        #region Core

        private readonly IQueryHandler<FindOrder, OrderDto> _findOrder;

        protected WhenSubmittingAnOrder(IntegrationTestingFactory<Startup> factory) : base(factory)
        {
            _findOrder = Resolve<IQueryHandler<FindOrder, OrderDto>>();
        }

        #endregion

        #region Protected Interface

        protected abstract void CreateSubmitOrderCommand();
        protected abstract OrderSubmitted HandleSubmitOrder();

        #endregion

        #region Test Methods

        [Fact]
        public void ThenTheOrderIsSaved()
        {
            CreateSubmitOrderCommand();
            var orderSubmitted = HandleSubmitOrder();

            var order = _findOrder.Handle(new FindOrder(orderSubmitted.Id));

            order.Should().NotBeNull();
        }

        #endregion
    }
}
