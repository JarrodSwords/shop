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
        RefundDue = (1 << 3) | Canceled,
        Refunded = (1 << 4) | Canceled,
        SaleComplete = 1 << 5
    }
}
