using System;

namespace Shop.Sales.Orders
{
    [Flags]
    public enum OrderStatus
    {
        Pending = 1,
        AwaitingConfirmation = 1 << 2,
        AwaitingFulfillment = 1 << 3,
        AwaitingPayment = 1 << 4,
        Canceled = 1 << 5,
        RefundDue = (1 << 6) | Canceled,
        Refunded = (1 << 7) | Canceled
    }
}
