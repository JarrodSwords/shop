namespace Shop.Catalog.Services
{
    public interface ICatalogService
    {
        ProductDto FindProduct(FindProduct command);
        ProductDto RegisterProduct(RegisterProduct command);
    }
}
