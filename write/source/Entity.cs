using System;

namespace Shop.Write
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

        #region Equality

        public override bool Equals(object obj) => Equals((Entity) obj);

        protected bool Equals(Entity other) => Id == other.Id;

        public override int GetHashCode() => Id.GetHashCode();

        #endregion

        #region Static Interface

        public static bool operator ==(Entity left, Entity right)
        {
            if (left is null)
                return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            if (left is null)
                return right != null;

            return !left.Equals(right);
        }

        #endregion
    }
}
