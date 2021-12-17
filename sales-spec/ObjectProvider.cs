using SalesOrder = Shop.Sales.Order;

namespace Shop.Sales.Spec
{
    public class ObjectProvider
    {
        #region Static Interface

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
