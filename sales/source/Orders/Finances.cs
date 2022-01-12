using System;
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
            Money refunded = default,
            Money subtotal = default,
            Money tip = default
        )
        {
            Due = due ?? Money.Zero;
            Paid = paid ?? Money.Zero;
            Refunded = refunded ?? Money.Zero;
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
        public bool IsPaidInFull => Paid >= Subtotal;
        public Money Paid { get; }
        public Money Refunded { get; }
        public Money Subtotal { get; }
        public Money Tip { get; }

        public Finances ApplyPayment(Money payment)
        {
            var difference = Due - payment;

            return new(
                Math.Max(difference, 0),
                Paid + payment,
                subtotal: Subtotal,
                tip: Math.Max(Tip - difference, 0)
            );
        }

        public Finances Refund() =>
            new(
                0,
                Paid,
                Subtotal,
                Tip,
                Paid
            );

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Due;
            yield return Paid;
            yield return Refunded;
            yield return Subtotal;
            yield return Tip;
        }

        #endregion
    }
}
