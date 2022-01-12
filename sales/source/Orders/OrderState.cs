using System;

namespace Shop.Sales.Orders
{
    [Flags]
    public enum OrderState
    {
        New = 0,
        AwaitingConfirmation = 1 << 0,
        AwaitingPayment = 1 << 1,
        Canceled = 1 << 2,
        Refunded = 1 << 3,
        RefundRequired = 1 << 4,
        SaleComplete = 1 << 5
    }

    public static class OrderStateExtensions
    {
        #region Static Interface

        public static OrderState With(this OrderState state, OrderState additional) => state | additional;

        #endregion
    }
}
