using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Shop.Sales
{
    public static class ObservableCollectionExtensions
    {
        #region Static Interface

        public static ObservableCollection<T> Remove<T>(
            this ObservableCollection<T> collection,
            Func<T, bool> predicate
        )
        {
            foreach (var item in collection.Where(predicate))
                collection.Remove(item);

            return collection;
        }

        #endregion
    }
}
