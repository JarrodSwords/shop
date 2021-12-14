using Shop.Domain.Catalog;

namespace Shop.Domain.Spec.Catalog
{
    public class ObjectProvider
    {
        public static Product LunchBox = new(
            "Each Lunch Box serves one and comes with one meat, one cheese, and accoutrements.",
            "Lunch Box",
            new(1),
            "MLC-LB-1"
        );
    }
}
