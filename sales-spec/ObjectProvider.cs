using SalesOrder = Shop.Sales.Order;

namespace Shop.Sales.Spec
{
    public class ObjectProvider
    {
        #region Static Interface

        public static Shop.Shared.Catalog.Product CreateLunchBox() =>
            new(
                "Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements.",
                "Lunch Box",
                new(1),
                "MLC-LB-1"
            );

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
