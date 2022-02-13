using System;
using Shop.Sales.Orders;
using DomainLineItem = Shop.Sales.Orders.Order.LineItemEntity;

namespace Shop.Write.Sales
{
    public class LineItem : Entity
    {
        #region Creation

        public LineItem(Guid id) : base(id)
        {
        }

        public LineItem(DomainLineItem source) : base(source.Id)
        {
            var (exclusions, price, productId) = source.Value;

            Update(exclusions);
            OrderId = source.OrderId;
            Price = price;
            ProductId = productId;
        }

        public static LineItem From(DomainLineItem source) => new(source);

        #endregion

        #region Public Interface

        public bool IsExcludingApricots { get; set; }
        public bool IsExcludingBerries { get; set; }
        public bool IsExcludingBleuCheese { get; set; }
        public bool IsExcludingBrie { get; set; }
        public bool IsExcludingCaramel { get; set; }
        public bool IsExcludingCherry { get; set; }
        public bool IsExcludingChocolate { get; set; }
        public bool IsExcludingDill { get; set; }
        public bool IsExcludingGarlic { get; set; }
        public bool IsExcludingGoatCheese { get; set; }
        public bool IsExcludingGrapes { get; set; }
        public bool IsExcludingGreenOlives { get; set; }
        public bool IsExcludingHoney { get; set; }
        public bool IsExcludingKalamataOlives { get; set; }
        public bool IsExcludingMustard { get; set; }
        public bool IsExcludingNuts { get; set; }
        public bool IsExcludingPeppers { get; set; }
        public bool IsExcludingPomegranateSeeds { get; set; }
        public bool IsExcludingProsciutto { get; set; }
        public bool IsExcludingSalami { get; set; }
        public bool IsExcludingSharpCheeses { get; set; }
        public bool IsExcludingSpicy { get; set; }
        public bool IsExcludingVanilla { get; set; }
        public Guid OrderId { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }

        public LineItem Update(LineItem target)
        {
            IsExcludingApricots = target.IsExcludingApricots;
            IsExcludingBerries = target.IsExcludingBerries;
            IsExcludingBleuCheese = target.IsExcludingBleuCheese;
            IsExcludingBrie = target.IsExcludingBrie;
            IsExcludingCaramel = target.IsExcludingCaramel;
            IsExcludingCherry = target.IsExcludingCherry;
            IsExcludingChocolate = target.IsExcludingChocolate;
            IsExcludingDill = target.IsExcludingDill;
            IsExcludingGarlic = target.IsExcludingGarlic;
            IsExcludingGoatCheese = target.IsExcludingGoatCheese;
            IsExcludingGrapes = target.IsExcludingGrapes;
            IsExcludingGreenOlives = target.IsExcludingGreenOlives;
            IsExcludingHoney = target.IsExcludingHoney;
            IsExcludingKalamataOlives = target.IsExcludingKalamataOlives;
            IsExcludingMustard = target.IsExcludingMustard;
            IsExcludingNuts = target.IsExcludingNuts;
            IsExcludingPeppers = target.IsExcludingPeppers;
            IsExcludingPomegranateSeeds = target.IsExcludingPomegranateSeeds;
            IsExcludingProsciutto = target.IsExcludingProsciutto;
            IsExcludingSalami = target.IsExcludingSalami;
            IsExcludingSharpCheeses = target.IsExcludingSharpCheeses;
            IsExcludingSpicy = target.IsExcludingSpicy;
            IsExcludingVanilla = target.IsExcludingVanilla;
            Price = target.Price;
            ProductId = target.ProductId;

            return this;
        }

        public LineItem Update(Options options)
        {
            IsExcludingApricots = options.HasFlag(Options.Apricots);
            IsExcludingBerries = options.HasFlag(Options.Berries);
            IsExcludingBleuCheese = options.HasFlag(Options.BleuCheese);
            IsExcludingBrie = options.HasFlag(Options.Brie);
            IsExcludingCaramel = options.HasFlag(Options.Caramel);
            IsExcludingCherry = options.HasFlag(Options.Cherry);
            IsExcludingChocolate = options.HasFlag(Options.Chocolate);
            IsExcludingDill = options.HasFlag(Options.Dill);
            IsExcludingGarlic = options.HasFlag(Options.Garlic);
            IsExcludingGoatCheese = options.HasFlag(Options.GoatCheese);
            IsExcludingGrapes = options.HasFlag(Options.Grapes);
            IsExcludingGreenOlives = options.HasFlag(Options.GreenOlives);
            IsExcludingHoney = options.HasFlag(Options.Honey);
            IsExcludingKalamataOlives = options.HasFlag(Options.KalamataOlives);
            IsExcludingMustard = options.HasFlag(Options.Mustard);
            IsExcludingNuts = options.HasFlag(Options.Nuts);
            IsExcludingPeppers = options.HasFlag(Options.Peppers);
            IsExcludingPomegranateSeeds = options.HasFlag(Options.PomegranateSeeds);
            IsExcludingProsciutto = options.HasFlag(Options.Prosciutto);
            IsExcludingSalami = options.HasFlag(Options.Salami);
            IsExcludingSharpCheeses = options.HasFlag(Options.SharpCheeses);
            IsExcludingSpicy = options.HasFlag(Options.Spicy);
            IsExcludingVanilla = options.HasFlag(Options.Vanilla);

            return this;
        }

        #endregion

        #region Static Interface

        public static implicit operator LineItem(DomainLineItem source) => new(source);

        #endregion
    }
}
