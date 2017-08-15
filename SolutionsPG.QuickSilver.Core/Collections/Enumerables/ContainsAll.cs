using System;
using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool ContainsAll<TItem, TObj>(this IEnumerable<TItem> enumerable, params TObj[] objToVerify) where TObj : TItem
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAll_(objToVerify);
        }

        public static bool ContainsAll<TItem, TObj>(this IEnumerable<TItem> enumerable, IEnumerable<TObj> objToVerify) where TObj : TItem
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

            return enumerable.ContainsAll_(objToVerify, comparer);
        }

        public static bool ContainsAll<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> objToVerify, IEqualityComparer<TItem> comparer)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));
            comparer.ThrowIfArgumentNull(nameof(comparer));

            return enumerable.ContainsAll_(objToVerify, comparer);
        }

        public static bool ContainsAll<TItem, TObj>(this IEnumerable<TItem> enumerable, Func<TObj, TItem, bool> comparison, params TObj[] objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            comparison.ThrowIfArgumentNull(nameof(comparison));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAll_(objToVerify, comparison);
        }

        public static bool ContainsAll<TItem, TObj>(this IEnumerable<TItem> enumerable, IEnumerable<TObj> objToVerify, Func<TObj, TItem, bool> comparison)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));
            comparison.ThrowIfArgumentNull(nameof(comparison));

            return enumerable.ContainsAll_(objToVerify, comparison);
        }

        #endregion //Public methods

        #region " Private methods "

        private static bool ContainsAll_<TItem, TObj>(this IEnumerable<TItem> enumerable, IEnumerable<TObj> objToVerify) where TObj : TItem
        {
            IEnumerable<TItem> memoizedEnumerable = (enumerable as ICollection<TItem>) ?? enumerable.Memoize();
            return objToVerify.All(EnumerableContainsObject);

            bool EnumerableContainsObject(TObj o) => memoizedEnumerable.Contains(o);
        }

        private static bool ContainsAll_<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> objToVerify, IEqualityComparer<TItem> comparer)
        {
            ICollection<TItem> memoizedEnumerable = (enumerable as ICollection<TItem>) ?? enumerable.Memoize();
            return objToVerify.All(EnumerableContainsObject);

            bool EnumerableContainsObject(TItem o) => memoizedEnumerable.Contains(o, comparer);
        }

        private static bool ContainsAll_<TItem, TObj>(this IEnumerable<TItem> enumerable, IEnumerable<TObj> objToVerify, Func<TObj, TItem, bool> comparison)
        {
            ICollection<TItem> memoizedEnumerable = (enumerable as ICollection<TItem>) ?? enumerable.Memoize();
            return objToVerify.All(EnumerableContainsObject);

            bool EnumerableContainsObject(TObj o)
            {
                return memoizedEnumerable.Any(Compare);
                bool Compare(TItem i) => comparison(o, i);
            }
        }

        #endregion //Private methods
    }
}
