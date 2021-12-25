﻿using Shop.Shared;

namespace Shop.Catalog
{
    public interface IProductBuilder
    {
        ProductCategory GetCategory();
        Description GetDescription();
        Name GetName();
        Money GetPrice();
        Size GetSize();
    }
}