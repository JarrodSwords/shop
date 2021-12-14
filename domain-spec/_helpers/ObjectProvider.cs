using Shop.Domain.Sales;
using FulfillmentOrder = Shop.Domain.Fulfillment.Order;
using Product = Shop.Domain.Catalog.Product;
using SalesOrder = Shop.Domain.Sales.Order;

namespace Shop.Domain.Spec
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

        public static SalesOrder CreateSubmittedOrder() => new();

        public static Customer CreateJohnDoe() =>
            new(
                "john.doe@gmail.com",
                "John",
                "Doe"
            );

        #endregion
    }
}
