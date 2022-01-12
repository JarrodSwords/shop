using Jgs.Functional.Explicit;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public interface IOrderable
    {
        Result<Error> ApplyPayment(Money value);
        Result<Error> Cancel();
        Result<Error> Confirm();
        Result<Error> IssueRefund();
    }
}
