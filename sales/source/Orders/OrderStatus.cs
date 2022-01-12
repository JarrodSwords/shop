using System;

namespace Shop.Sales.Orders
{
    [Flags]
    public enum OrderStatus
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

        public static OrderStatus With(this OrderStatus status, OrderStatus additional) => status | additional;

        #endregion
    }
}
