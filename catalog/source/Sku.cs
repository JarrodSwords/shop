using System.Linq;
using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Catalog
{
    public class Sku : TinyType<string>
    {
        #region Creation

        public Sku(string value) : base(value)
        {
        }

        public static Sku Create(params Token[] tokens)
        {
            var sku = tokens
                .Where(t => t != default)
                .Aggregate("", (current, t) => current + $"-{t}");

            return new Sku(sku.TrimStart('-'));
        }

        #endregion

        #region Static Interface

        public static implicit operator Sku(string value) => new(value);

        #endregion
    }
}
