using System;
using DomainProduct = Shop.Sales.Product;

namespace Shop.Write
{
    public class Product : Entity
    {
        #region Creation

        public Product(Guid id) : base(id)
        {
        }

        private Product(DomainProduct source) : base(source.Id)
        {
            Description = source.Description;
            Name = source.Name;
            Price = source.Price;
            Sku = source.Sku;
        }

        #endregion

        #region Public Interface

        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }

        #endregion

        #region Static Interface

        public static implicit operator Product(DomainProduct source) => new(source);

        #endregion
    }
}
