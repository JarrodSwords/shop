using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Sales;

namespace Shop.Infrastructure
{
    public class Context : DbContext
    {
        #region Creation

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        #endregion

        #region Public Interface

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }

        #endregion
    }
}
