﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Jgs.Ddd;

namespace Shop.Write
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly Context Context;

        #region Creation

        public Repository(Context context)
        {
            Context = context;
        }

        #endregion

        #region IRepository<T> Implementation

        public Id Create(T entity) => Context.Set<T>().Add(entity).Entity.Id;

        public IRepository<T> Create(params T[] entities)
        {
            Context.Set<T>().AddRange(entities);
            return this;
        }

        public bool Exists(Expression<Func<T, bool>> predicate) =>
            Context
                .Set<T>()
                .AsQueryable()
                .Any(predicate);

        public T Find(Id id) => Context.Set<T>().Find((Guid) id);

        public T Find(Expression<Func<T, bool>> predicate) =>
            Context
                .Set<T>()
                .AsQueryable()
                .SingleOrDefault(predicate);

        public IRepository<T> Update(T entity)
        {
            Context.Set<T>().Update(entity);
            return this;
        }

        #endregion
    }
}
