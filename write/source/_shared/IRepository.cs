using System;
using System.Linq.Expressions;
using Jgs.Ddd;

namespace Shop.Write
{
    public interface IRepository<T> where T : Entity
    {
        Id Create(T entity);
        bool Exists(Expression<Func<T, bool>> predicate);
        T Find(Expression<Func<T, bool>> predicate);
    }
}
