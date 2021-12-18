using Shop.Sales.Services;

namespace Shop.Api.Spec.Sales
{
    public class ObjectProvider
    {
        #region Static Interface

        public static CustomerDto GetJaneDoe() =>
            new(
                "jane.doe@gmail.com",
                "Jane",
                "Doe"
            );

        public static CustomerDto GetJonDoe() =>
            new(
                "jon.doe@gmail.com",
                "Jon",
                "Doe"
            );

        public static OrderDetailsDto GetLunchBox() => new(LunchBoxes: 1);

        #endregion
    }
}
