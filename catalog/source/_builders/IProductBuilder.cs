namespace Shop.Catalog
{
    public interface IProductBuilder
    {
        IProductBuilder FindVendor();
        IProductBuilder GenerateSku();
    }
}
