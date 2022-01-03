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
                    ProductCategories.Box,
                    "Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements.",
                    "Lunch Box",
                    "lun"
                ),
                new(
                    ProductCategories.Box,
                    "Each Couples Box serves approximately two and comes with two meats, two cheeses, and accoutrements."
                    ,
                    "Couples Box",
                    "cpl"
                ),
                new(
                    ProductCategories.Box,
                    "Each Family Box serves approximately four to six and comes with three meats, three cheeses, and accoutrements."
                    ,
                    "Family Box",
                    "fam"
                ),
                new(
                    ProductCategories.Box,
                    "Each Party Box serves approximately six to eight and comes with four meats, four cheeses, and accoutrements."
                    ,
                    "Party Box",
                    "pty"
                ),
                new(
                    ProductCategories.Box | ProductCategories.Dessert,
                    "Each Dessert Box comes with an assortment of seasonal chocolates, cookies, pastries, and other accoutrements. Serves approximately 2-4."
                    ,
                    "Dessert Box",
                    "dst"
                ),
                new(
                    ProductCategories.Side,
                    "A fresh French baguette.",
                    "Baguette",
                    "bgt"
                ),
                new(
                    ProductCategories.Dessert | ProductCategories.Side,
                    "Fresh strawberries covered in milk or dark chocolate.",
                    "Chocolate-covered Strawberries",
                    "stw",
                    Size: 6
                ),
                new(
                    ProductCategories.Dessert | ProductCategories.Side,
                    "Fresh strawberries covered in milk or dark chocolate.",
                    "Chocolate-covered Strawberries",
                    "stw",
                    Size: 12
                ),
                new(
                    ProductCategories.Dessert | ProductCategories.Side,
                    "Fresh strawberries covered in milk or dark chocolate.",
                    "Chocolate-covered Strawberries",
                    "stw",
                    Size: 24
                ),
                new(
                    ProductCategories.Dessert | ProductCategories.Side,
                    "Fresh strawberries covered in milk or dark chocolate.",
                    "Chocolate-covered Strawberries",
                    "stw",
                    Size: 36
                ),
                new(
                    ProductCategories.Dessert | ProductCategories.Side,
                    "Fresh strawberries covered in milk or dark chocolate.",
                    "Chocolate-covered Strawberries",
                    "stw",
                    Size: 48
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

                var productBuilder = new CandidateProduct.ProductBuilder();

                foreach (var p in _products)
                {
                    var product = productBuilder.With(p).Build();
                    Uow.Products.Create(product);
                }

                Uow.Commit();
            }

            #endregion

            private record CandidateProduct(
                ProductCategories Categories,
                Description Description,
                Name Name,
                Token SkuToken,
                Company Company = default,
                Size Size = default
            )
            {
                public class ProductBuilder : IProductBuilder
                {
                    private Product.Builder _builder;
                    private CandidateProduct _candidate;
                    private Company _company;

                    #region Public Interface

                    public Product Build() => _builder.Build().Value;

                    public ProductBuilder With(CandidateProduct candidate)
                    {
                        _candidate = candidate;
                        return this;
                    }

                    #endregion

                    #region IProductBuilder Implementation

                    public IProductBuilder FindCompany()
                    {
                        _company = Company.ManyLoves;
                        return this;
                    }

                    public IProductBuilder GenerateSku()
                    {
                        var sku = Product.GenerateSku(
                            _company.SkuToken,
                            _candidate.Categories.GetToken(),
                            _candidate.SkuToken
                        );

                        _builder.With(sku);

                        return this;
                    }

                    #endregion
                }
            }
        }
    }
}
