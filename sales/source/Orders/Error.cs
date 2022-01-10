using Shop.Shared;

namespace Shop.Sales.Orders
{
    public static class ErrorExtensions
    {
        #region Static Interface

        public static Error CustomerNotFound() => new("customer.not.found", "Could not find customer.");
        public static Error OrderAlreadyCanceled() => new("order.already.canceled", "Cannot cancel a canceled order.");

        #endregion
    }
}
