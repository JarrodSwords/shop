using System;
using System.Collections.Generic;
using System.Linq;
using Jgs.Ddd;
using Shop.Shared;
using static Shop.Shared.Money;

namespace Shop.Sales.Orders
{
    public class Finances : ValueObject
    {
        public static Finances Default = new();

        #region Creation

        public Finances(
            Money balance = default,
            Money paid = default,
            Money refunded = default,
            Money subtotal = default,
            Money tip = default
        )
        {
            Balance = balance ?? Zero;
            Paid = paid ?? Zero;
            Refunded = refunded ?? Zero;
            Subtotal = subtotal ?? Zero;
            Tip = tip ?? Zero;
        }

        public static Finances From(params LineItem[] lineItems)
        {
            if (lineItems.Length == 0)
                return Default;

            var subtotal = lineItems.Aggregate(
                Zero,
                (current, x) => current += x.Price
            );

            return new(
                subtotal,
                subtotal: subtotal
            );
        }

        public static Finances From(Finances previous, params LineItem[] lineItems)
        {
            var finances = From(lineItems);

            return new(
                finances.Balance,
                previous.Paid,
                previous.Refunded,
                finances.Subtotal,
                previous.Tip
            );
        }

        #endregion

        #region Public Interface

        public Money Balance { get; }
        public bool IsPaidInFull => Paid >= Subtotal;
        public Money Paid { get; }
        public Money Refunded { get; }
        public Money Subtotal { get; }
        public Money Tip { get; }

        public Finances ApplyPayment(Money payment)
        {
            var remainingBalance = Balance - payment;

            return new(
                Math.Max(remainingBalance, 0),
                Paid + payment,
                subtotal: Subtotal,
                tip: Math.Max(Tip - remainingBalance, 0)
            );
        }

        public Finances Cancel() => new(Zero, Paid, Refunded, Subtotal, Tip);

        public void Deconstruct(
            out Money balance,
            out Money paid,
            out Money refunded,
            out Money subtotal,
            out Money tip
        )
        {
            balance = Balance;
            paid = Paid;
            refunded = Refunded;
            subtotal = Subtotal;
            tip = Tip;
        }

        public Finances IssueRefund() => new(Zero, Paid, Paid, Subtotal, Tip);

        public override string ToString() =>
            $@"{nameof(Balance)}: {Balance}; 
{nameof(Paid)}: {Paid}; 
{nameof(Refunded)}: {Refunded}; 
{nameof(Subtotal)}: {Subtotal}; 
{nameof(Tip)}: {Tip}";

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Balance;
            yield return Paid;
            yield return Refunded;
            yield return Subtotal;
            yield return Tip;
        }

        #endregion
    }
}
