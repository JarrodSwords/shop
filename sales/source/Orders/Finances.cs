﻿using System;
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
                (current, x) => current += x.Price * x.Quantity
            );

            return new(
                subtotal,
                subtotal: subtotal
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

        public Finances Cancel() => new(Zero, Paid, Subtotal, Tip, Paid);

        public Finances IssueRefund() =>
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
            yield return Balance;
            yield return Paid;
            yield return Refunded;
            yield return Subtotal;
            yield return Tip;
        }

        #endregion
    }
}
