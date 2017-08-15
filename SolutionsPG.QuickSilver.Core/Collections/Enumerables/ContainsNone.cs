using System;
using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool ContainsNone<TItem, TObj>(this IEnumerable<TItem> enumerable, params TObj[] objToVerify) where TObj : TItem
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAny_(objToVerify) == false;
        }

        public static bool ContainsNone<TItem, TObj>(this IEnumerable<TItem> enumerable, IEnumerable<TObj> objToVerify) where TObj : TItem
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAny_(objToVerify) == false;
        }

        public static bool ContainsNone<TItem>(this IEnumerable<TItem> enumerable, IEqualityComparer<TItem> comparer, params TItem[] objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            comparer.ThrowIfArgumentNull(nameof(comparer));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAny_(objToVerify, comparer) == false;
        }

        public static bool ContainsNone<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> objToVerify, IEqualityComparer<TItem> comparer)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));
            comparer.ThrowIfArgumentNull(nameof(comparer));

            return enumerable.ContainsAny_(objToVerify, comparer) == false;
        }

        public static bool ContainsNone<TItem, TObj>(this IEnumerable<TItem> enumerable, Func<TObj, TItem, bool> comparison, params TObj[] objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            comparison.ThrowIfArgumentNull(nameof(comparison));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAny_(objToVerify, comparison) == false;
        }

        public static bool ContainsNone<TItem, TObj>(this IEnumerable<TItem> enumerable, IEnumerable<TObj> objToVerify, Func<TObj, TItem, bool> comparison)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));
            comparison.ThrowIfArgumentNull(nameof(comparison));

            return enumerable.ContainsAny_(objToVerify, comparison) == false;
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
