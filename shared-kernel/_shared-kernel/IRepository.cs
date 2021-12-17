using Jgs.Ddd;

namespace Shop.Shared
{
    public interface IRepository<T> where T : Aggregate
    {
    }
}
