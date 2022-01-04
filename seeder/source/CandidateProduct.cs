using Shop.Catalog;
using Shop.Shared;

namespace Shop.Seeder
{
    public record CandidateProduct(
        Name Name,
        Token SkuToken,
        ProductCategories Categories,
        Description Description,
        Size Size = default
    )
    {
        public static readonly CandidateProduct[] All =
        {
            new(
                "Lunch Box",
                "lun",
                ProductCategories.Box,
                "Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements."
            ),
            new(
                "Couples Box",
                "cpl",
                ProductCategories.Box,
                "Each Couples Box serves approximately two and comes with two meats, two cheeses, and accoutrements."
            ),
            new(
                "Family Box",
                "fam",
                ProductCategories.Box,
                "Each Family Box serves approximately four to six and comes with three meats, three cheeses, and accoutrements."
            ),
            new(
                "Party Box",
                "pty",
                ProductCategories.Box,
                "Each Party Box serves approximately six to eight and comes with four meats, four cheeses, and accoutrements."
            ),
            new(
                "Dessert Box",
                "dst",
                ProductCategories.Box | ProductCategories.Dessert,
                "Each Dessert Box comes with an assortment of seasonal chocolates, cookies, pastries, and other accoutrements. Serves approximately 2-4."
            ),
            new(
                "Baguette",
                "bgt",
                ProductCategories.Side,
                "A fresh French baguette."
            ),
            new(
                "Chocolate-covered Strawberries",
                "stw",
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                6
            ),
            new(
                "Chocolate-covered Strawberries",
                "stw",
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                12
            ),
            new(
                "Chocolate-covered Strawberries",
                "stw",
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                24
            ),
            new(
                "Chocolate-covered Strawberries",
                "stw",
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                36
            ),
            new(
                "Chocolate-covered Strawberries",
                "stw",
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                48
            )
        };
    }
}
