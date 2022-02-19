using Shop.Shared;

namespace Shop.Sales.Orders
{
    public static class ErrorExtensions
    {
        #region Static Interface

        public static Error CouldNotCreateOrder() => new("could.not.create.order", "Could not create order.");
        public static Error CustomerNotFound() => new("customer.not.found", "Could not find customer.");
        public static Error LineItemNotFound() => new("line.item.not.found", "Could not find line item.");

        #endregion
    }
}
