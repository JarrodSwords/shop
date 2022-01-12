using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Sales.Orders
{
    public class Finances : ValueObject
    {
        public static Finances Default = new();

        #region Creation

        public Finances(
            Money due = default,
            Money paid = default,
            Money subtotal = default,
            Money tip = default
        )
        {
            Due = due ?? Money.Zero;
            Paid = paid ?? Money.Zero;
            Subtotal = subtotal ?? Money.Zero;
            Tip = tip ?? Money.Zero;
        }

        public static Finances From(params LineItem[] lineItems)
        {
            if (lineItems.Length == 0)
                return Default;

            var subtotal = lineItems.Aggregate(
                Money.Zero,
                (current, x) => current += x.Price * x.Quantity
            );

            return new(
                subtotal,
                subtotal: subtotal
            );
        }

        #endregion

        #region Public Interface

        public Money Due { get; }
        public Money Paid { get; }
        public Money Subtotal { get; }
        public Money Tip { get; }

        public Finances ApplyPayment(Money payment) =>
            new(
                Due - payment,
                Paid + payment,
                Subtotal,
                Tip
            );

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Due;
            yield return Paid;
            yield return Subtotal;
            yield return Tip;
        }

        #endregion
    }
}
