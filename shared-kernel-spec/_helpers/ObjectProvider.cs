using Shop.Shared.Catalog;
using FulfillmentOrder = Shop.Shared.Fulfillment.Order;

namespace Shop.Shared
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

        public static FulfillmentOrder CreateOrderPendingDelivery() => new();

        public static Order CreateSubmittedOrder() => new();

        public static Customer CreateJohnDoe() =>
            new(
                "john.doe@gmail.com",
                "John",
                "Doe"
            );

        #endregion
    }
}
