using System.Collections.Generic;
using Shop.Catalog;

namespace Shop.Seeder
{
    public class ObjectProvider
    {
        public static readonly List<RegisterProduct> Products = new()
        {
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Box,
                "Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements.",
                "Lunch Box",
                "lun"
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Box,
                "Each Couples Box serves approximately two and comes with two meats, two cheeses, and accoutrements.",
                "Couples Box",
                "cpl"
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Box,
                "Each Family Box serves approximately four to six and comes with three meats, three cheeses, and accoutrements."
                ,
                "Family Box",
                "fam"
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Box,
                "Each Party Box serves approximately six to eight and comes with four meats, four cheeses, and accoutrements."
                ,
                "Party Box",
                "pty"
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Box | ProductCategories.Dessert,
                "Each Dessert Box comes with an assortment of seasonal chocolates, cookies, pastries, and other accoutrements. Serves approximately 2-4."
                ,
                "Dessert Box",
                "dst"
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Side,
                "A fresh French baguette.",
                "Baguette",
                "bgt"
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                "Chocolate-covered Strawberries",
                "stw",
                6
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                "Chocolate-covered Strawberries",
                "stw",
                12
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                "Chocolate-covered Strawberries",
                "stw",
                24
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                "Chocolate-covered Strawberries",
                "stw",
                36
            ),
            new(
                Vendor.ManyLoves.Id,
                ProductCategories.Dessert | ProductCategories.Side,
                "Fresh strawberries covered in milk or dark chocolate.",
                "Chocolate-covered Strawberries",
                "stw",
                48
            )
        };
    }
}
