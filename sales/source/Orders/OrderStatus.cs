using System;

namespace Shop.Sales.Orders
{
    [Flags]
    public enum OrderStatus
    {
        Pending = 0,
        AwaitingConfirmation = 1 << 0,
        AwaitingFulfillment = 1 << 1,
        AwaitingPayment = 1 << 2,
        Canceled = 1 << 3,
        RefundDue = (1 << 4) | Canceled,
        Refunded = (1 << 5) | Canceled
    }
}
