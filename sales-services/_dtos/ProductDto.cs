namespace Shop.Sales.Services
{
    public record ProductDto(
        string Description,
        string Name,
        decimal Price,
        string Sku
    );
}
