using System;

namespace Shop.Sales.Orders
{
    [Flags]
    public enum OrderStates
    {
        AwaitingConfirmation = 1 << 0,
        AwaitingPayment = 1 << 1
    }
}
