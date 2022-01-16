using Jgs.Ddd;
using Shop.Shared;

namespace Shop.Seeder
{
    public record Product(
        Id VendorId,
        ProductCategories Categories,
        Description Description,
        Name Name,
        Money Price,
        Token SkuToken,
        Size Size = default,
        Sku Sku = default
    );
}
