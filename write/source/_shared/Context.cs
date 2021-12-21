using Microsoft.EntityFrameworkCore;

namespace Shop.Write
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
        public DbSet<Product> Product { get; set; }

        #endregion
    }
}
