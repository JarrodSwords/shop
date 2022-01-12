namespace Shop.Sales.Orders
{
    public enum OrderState
    {
        AwaitingConfirmation,
        AwaitingFulfillment,
        AwaitingPayment,
        Canceled
    }
}
