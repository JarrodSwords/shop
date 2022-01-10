using Shop.Shared;

namespace Shop.Sales.Orders
{
    public static class ErrorExtensions
    {
        #region Static Interface

        public static Error CustomerNotFound() => new("customer.not.found", "Could not find customer.");

        #endregion
    }
}
