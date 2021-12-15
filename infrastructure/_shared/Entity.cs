using System;

namespace Shop.Infrastructure
{
    public abstract class Entity
    {
        #region Creation

        protected Entity(Guid id)
        {
            Id = id;
        }

        #endregion

        #region Public Interface

        public Guid Id { get; set; }

        #endregion
    }
}
