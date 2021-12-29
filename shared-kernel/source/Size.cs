﻿using Jgs.Ddd;

namespace Shop.Shared
{
    public class Size : TinyType<ushort>
    {
        #region Creation

        public Size(ushort value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Size(ushort source) => new(source);

        #endregion
    }
}
