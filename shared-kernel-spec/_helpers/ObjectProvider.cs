using Shop.Shared.Catalog;
using Shop.Shared.Fulfillment;

namespace Shop.Shared.Spec
{
    public class ObjectProvider
    {
        #region Static Interface

        public static Product CreateLunchBox() =>
            new(
                "Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements.",
                "Lunch Box",
                new(1),
                "MLC-LB-1"
            );

        public static Order CreateOrderPendingDelivery() => new();

        public static Order CreateSubmittedOrder() => new();

        #endregion
    }
}
