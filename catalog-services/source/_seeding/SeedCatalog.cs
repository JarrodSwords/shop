using System.Linq;
using Jgs.Cqrs;
using Shop.Shared;

namespace Shop.Catalog.Services
{
    public record SeedCatalog : ICommand
    {
        public class Handler : Handler<SeedCatalog>
        {
            private readonly CandidateProduct[] _products =
            {
                new(
                    ProductCategory.Box,
                    "Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements.",
                    "Lunch Box",
                    "lun"
                ),
                new(
                    ProductCategory.Box,
                    "Each Couples Box serves approximately two and comes with two meats, two cheeses, and accoutrements."
                    ,
                    "Couples Box",
                    "cpl"
                ),
                new(
                    ProductCategory.Box,
                    "Each Family Box serves approximately four to six and comes with three meats, three cheeses, and accoutrements."
                    ,
                    "Family Box",
                    "fam"
                ),
                new(
                    ProductCategory.Box,
                    "Each Party Box serves approximately six to eight and comes with four meats, four cheeses, and accoutrements."
                    ,
                    "Party Box",
                    "pty"
                ),
                new(
                    ProductCategory.Dessert,
                    "Each Dessert Box comes with an assortment of seasonal chocolates, cookies, pastries, and other accoutrements. Serves approximately 2-4."
                    ,
                    "Dessert Box",
                    "des"
                ),
                new(
                    ProductCategory.Side,
                    "A fresh French baguette."
                    ,
                    "Baguette",
                    "bgt"
                )
            };

            #region Creation

            public Handler(IUnitOfWork uow) : base(uow)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(SeedCatalog args)
            {
                Uow.Companies.Create(Company.ManyLoves);

                Uow.Products.Create(_products.Select(x => Product.From(x).Value).ToArray());

                Uow.Commit();
            }

            #endregion

            private record CandidateProduct(
                ProductCategory Category,
                Description Description,
                Name Name,
                Token SkuToken,
                Company Company = default,
                Size Size = default
            ) : IProductBuilder
            {
                #region IProductBuilder Implementation

                public ProductCategory GetCategory() => Category;
                public Company GetCompany() => Company ?? Company.ManyLoves;
                public Description GetDescription() => Description;
                public Name GetName() => Name;
                public Size GetSize() => Size;
                public Token GetSkuToken() => SkuToken;

                #endregion
            }
        }
    }
}
