namespace Shop.Sales.Orders
{
    public enum OrderState
    {
        AwaitingConfirmation,
        AwaitingPayment,
        Canceled,
        Refunded,
        SaleComplete
    }
}
