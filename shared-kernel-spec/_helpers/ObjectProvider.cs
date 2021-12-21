using Shop.Shared.Fulfillment;

namespace Shop.Shared.Spec
{
    public class ObjectProvider
    {
        #region Static Interface

        public static Order CreateOrderPendingDelivery() => new();

        #endregion
    }
}
