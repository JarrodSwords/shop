﻿using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Shared;

namespace Shop.Catalog
{
    [Flags]
    public enum ProductCategories : ushort
    {
        None = 0,
        Box = 1 << 0,
        Dessert = 1 << 1,
        Side = 1 << 2
    }

    public static class ProductCategoriesExtensions
    {
        private static readonly Dictionary<ProductCategories, string> _tokens = new()
        {
            { ProductCategories.None, "n" },
            { ProductCategories.Box, "b" },
            { ProductCategories.Dessert, "d" },
            { ProductCategories.Side, "s" }
        };

        #region Static Interface

        public static Token GetToken(this ProductCategories categories)
        {
            var token = Enum.GetValues<ProductCategories>()
                .Where(c => categories.HasFlag(c))
                .Aggregate("", (current, c) => current + _tokens[c]);

            return token.Length > 1
                ? token.TrimStart('n')
                : token;
        }

        #endregion
    }
}
