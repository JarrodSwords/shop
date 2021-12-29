﻿using System;
using System.Linq;
using Shop.Catalog;
using DomainProduct = Shop.Catalog.Product;

namespace Shop.Write.Catalog
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        #region Creation

        public ProductRepository(Context context) : base(context)
        {
        }

        #endregion

        #region IProductRepository Implementation

        public Guid Create(DomainProduct product) => base.Create(product);

        public IProductRepository Create(params DomainProduct[] products)
        {
            base.Create(products.Select(Product.From).ToArray());
            return this;
        }

        #endregion
    }
}
