using System.Collections.Generic;
using Jgs.Ddd;

namespace Shop.Shared
{
    public class Serves : ValueObject
    {
        #region Creation

        public Serves(ushort max, ushort min = default)
        {
            Max = max;
            Min = min;
        }

        #endregion

        #region Public Interface

        public ushort Max { get; }
        public ushort Min { get; }

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Max;
            yield return Min;
        }

        #endregion
    }
}
