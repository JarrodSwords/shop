﻿using System;
using Jgs.Cqrs;

namespace Shop.Catalog.Services
{
    public record FindCompany(Guid id) : IQuery
    {
        #region Static Interface

        public static implicit operator FindCompany(Guid source) => new(source);

        #endregion
    }
}