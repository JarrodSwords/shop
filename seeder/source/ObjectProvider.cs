using System.Collections.Generic;
using Shop.Catalog;
using Shop.Shared;

namespace Shop.Seeder
{
    public class ObjectProvider
    {
        public static readonly List<Product> Products = new()
        {
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Box,
                "Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements.",
                "Lunch Box",
                25,
                "lun"
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Box,
                "Each Couples Box serves approximately two and comes with two meats, two cheeses, and accoutrements.",
                "Couples Box",
                39,
                "cpl"
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Box,
                "Each Family Box serves approximately four to six and comes with three meats, three cheeses, and accoutrements."
                ,
                "Family Box",
                69,
                "fam"
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Box,
                "Each Party Box serves approximately six to eight and comes with four meats, four cheeses, and accoutrements."
                ,
                "Party Box",
                99,
                "pty"
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Box | ProductCategories.Dessert,
                "Each Dessert Box comes with an assortment of seasonal chocolates, cookies, pastries, and other accoutrements. Serves approximately 2-4."
                ,
                "Dessert Box",
                25,
                "dst"
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Side,
                "A fresh French baguette.",
                "Baguette",
                4,
                "bgt"
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                "Chocolate-covered Strawberries",
                15,
                "stw",
                6
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                "Chocolate-covered Strawberries",
                28,
                "stw",
                12
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                "Chocolate-covered Strawberries",
                56,
                "stw",
                24
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                "Chocolate-covered Strawberries",
                84,
                "stw",
                36
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                "Chocolate-covered Strawberries",
                112,
                "stw",
                48
            )
        };
    }
}
