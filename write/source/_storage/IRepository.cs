using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Jgs.Ddd;

namespace Shop.Write
{
    public interface IRepository<T> where T : Entity
    {
        void Create(T entity);
        IRepository<T> Create(params T[] entities);
        bool Exists(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Fetch();
        T Find(Id id);
        T Find(Expression<Func<T, bool>> predicate);
        IRepository<T> Update(T entity);
    }
}
