using System.Collections.Generic;
using Jgs.Ddd;
using Shop.Domain.Sales;

namespace Shop.ApplicationServices.Spec.Sales
{
    public class OrderRepository : IOrderRepository
    {
        public readonly List<Order> Orders = new();

        #region IOrderRepository Implementation

        public Id Create(Order order)
        {
            Orders.Add(order);
            return order.Id;
        }

        #endregion
    }
}
