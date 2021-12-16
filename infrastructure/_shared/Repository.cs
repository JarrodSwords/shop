using System;
using System.Linq;
using System.Linq.Expressions;
using Jgs.Ddd;

namespace Shop.Infrastructure
{
    internal class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly Context _context;

        #region Creation

        public Repository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IRepository<T> Implementation

        public Id Create(T entity) =>
            _context
                .Set<T>()
                .Add(entity).Entity.Id;

        public bool Exists(Expression<Func<T, bool>> predicate) =>
            _context
                .Set<T>()
                .AsQueryable()
                .Any(predicate);

        public T Find(Expression<Func<T, bool>> predicate) =>
            _context
                .Set<T>()
                .AsQueryable()
                .SingleOrDefault(predicate);

        #endregion
    }
}
