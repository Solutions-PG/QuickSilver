using System;
using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool ContainsAll<TItem>(this IEnumerable<TItem> enumerable, params TItem[] objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAll_(objToVerify);
        }

        public static bool ContainsAll<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAll_(objToVerify);
        }

        public static bool ContainsAll<TItem>(this IEnumerable<TItem> enumerable, IEqualityComparer<TItem> comparer, params TItem[] objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            comparer.ThrowIfArgumentNull(nameof(comparer));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAll_(comparer, objToVerify);
        }

        public static bool ContainsAll<TItem>(this IEnumerable<TItem> enumerable, IEqualityComparer<TItem> comparer, IEnumerable<TItem> objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));
            comparer.ThrowIfArgumentNull(nameof(comparer));

            return enumerable.ContainsAll_(comparer, objToVerify);
        }

        public static bool ContainsAll<TItem, TObj>(this IEnumerable<TItem> enumerable, Func<TObj, TItem, bool> comparison, params TObj[] objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            comparison.ThrowIfArgumentNull(nameof(comparison));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAll_(comparison, objToVerify);
        }

        public static bool ContainsAll<TItem, TObj>(this IEnumerable<TItem> enumerable, Func<TObj, TItem, bool> comparison, IEnumerable<TObj> objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));
            comparison.ThrowIfArgumentNull(nameof(comparison));

            return enumerable.ContainsAll_(comparison, objToVerify);
        }

        #endregion //Public methods

        #region " Private methods "

        private static bool ContainsAll_<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> objToVerify)
        {
            IEnumerable<TItem> memoizedEnumerable = (enumerable as ICollection<TItem>) ?? enumerable.Memoize();

            bool EnumerableContainsObject(TItem o) => memoizedEnumerable.Contains(o);
            return objToVerify.All(EnumerableContainsObject);
        }

        private static bool ContainsAll_<TItem>(this IEnumerable<TItem> enumerable, IEqualityComparer<TItem> comparer, IEnumerable<TItem> objToVerify)
        {
            ICollection<TItem> memoizedEnumerable = (enumerable as ICollection<TItem>) ?? enumerable.Memoize();

            bool EnumerableContainsObject(TItem o) => memoizedEnumerable.Contains(o, comparer);
            return objToVerify.All(EnumerableContainsObject);
        }

        private static bool ContainsAll_<TItem, TObj>(this IEnumerable<TItem> enumerable, Func<TObj, TItem, bool> comparison, IEnumerable<TObj> objToVerify)
        {
            ICollection<TItem> memoizedEnumerable = (enumerable as ICollection<TItem>) ?? enumerable.Memoize();

            bool EnumerableContainsObject(TObj o)
            {
                return memoizedEnumerable.Any(Compare);
                bool Compare(TItem i) => comparison(o, i);
            }
            return objToVerify.All(EnumerableContainsObject);
        }

        #endregion //Private methods
    }
}
