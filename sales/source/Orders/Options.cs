using System;

namespace Shop.Sales.Orders
{
    [Flags]
    public enum Options
    {
        None = 0,
        Apricots = 1 << 0,
        Berries = 1 << 1,
        BleuCheese = 1 << 2,
        Brie = 1 << 3,
        Caramel = 1 << 4,
        Cherry = 1 << 5,
        Chocolate = 1 << 6,
        Dill = 1 << 7,
        Garlic = 1 << 8,
        GoatCheese = 1 << 9,
        Grapes = 1 << 10,
        GreenOlives = 1 << 11,
        Honey = 1 << 12,
        KalamataOlives = 1 << 13,
        Mustard = 1 << 14,
        Nuts = 1 << 15,
        Peppers = 1 << 16,
        PomegranateSeeds = 1 << 17,
        Prosciutto = 1 << 18,
        Salami = 1 << 19,
        SharpCheeses = 1 << 20,
        Spicy = 1 << 21,
        Vanilla = 1 << 22,
        Cheese = Brie | BleuCheese | GoatCheese | SharpCheeses,
        Fruit = Apricots | Berries | Grapes | PomegranateSeeds,
        Meat = Prosciutto | Salami,
        Misc = Dill | Garlic | GreenOlives | KalamataOlives | Mustard | Nuts | Peppers | Spicy,
        Sweets = Caramel | Cherry | Chocolate | Honey | Vanilla,
        All = Cheese | Fruit | Meat | Misc | Sweets
    }
}
