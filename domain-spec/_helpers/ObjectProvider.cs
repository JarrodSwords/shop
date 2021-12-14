using Shop.Domain.Sales;
using FulfillmentOrder = Shop.Domain.Fulfillment.Order;
using Product = Shop.Domain.Catalog.Product;
using SalesOrder = Shop.Domain.Sales.Order;

namespace Shop.Domain.Spec
{
    public class ObjectProvider
    {
        public static CandidateOrderDto CandidateOrder = new();

        public static Product LunchBox = new(
            "Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements.",
            "Lunch Box",
            new(1),
            "MLC-LB-1"
        );

        public static FulfillmentOrder OrderPendingDelivery = new();

        public static SalesOrder SubmittedOrder = new();
    }
}
