using Jgs.Ddd;
using Shop.Catalog;
using Shop.Shared;
using Sku = Shop.Shared.Sku;

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
