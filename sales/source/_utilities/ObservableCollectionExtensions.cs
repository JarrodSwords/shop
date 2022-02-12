using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Shop.Sales
{
    public static class ObservableCollectionExtensions
    {
        #region Static Interface

        public static ObservableCollection<T> AddRange<T>(
            this ObservableCollection<T> collection,
            IEnumerable<T> values
        )
        {
            foreach (var value in values)
                collection.Add(value);

            return collection;
        }

        public static ObservableCollection<T> Remove<T>(
            this ObservableCollection<T> collection,
            Func<T, bool> predicate
        )
        {
            foreach (var item in collection.Where(predicate))
                collection.Remove(item);

            return collection;
        }

        public static ObservableCollection<T> RemoveLast<T>(
            this ObservableCollection<T> collection,
            Func<T, bool> predicate
        )
        {
            var item = collection.Where(predicate).Last();

            collection.Remove(item);

            return collection;
        }

        #endregion
    }
}
