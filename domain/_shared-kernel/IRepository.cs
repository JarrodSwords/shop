using Jgs.Ddd;

namespace Shop.Domain
{
    public interface IRepository<T> where T : Aggregate
    {
    }
}
