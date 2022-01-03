namespace Shop.Catalog
{
    public interface IProductBuilder
    {
        IProductBuilder FindCompany();
        IProductBuilder GenerateSku();
    }
}
