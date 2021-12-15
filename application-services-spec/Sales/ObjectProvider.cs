using Shop.ApplicationServices.Sales;
using Shop.Domain.Sales;

namespace Shop.ApplicationServices.Spec.Sales
{
    public class ObjectProvider
    {
        #region Static Interface

        public static CustomerDto GetJohnDoe() => new("john.doe@gmail.com", "John", "Doe");
        public static IUnitOfWork CreateUnitOfWork() => new UnitOfWork();

        #endregion
    }
}
