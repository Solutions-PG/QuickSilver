using System;
using System.Collections.Generic;
using System.Linq;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool DoesNotContain<TItem, TObj>(this IEnumerable<TItem> enumerable, TObj objToVerify) where TObj : TItem
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));

            return enumerable.Contains_(objToVerify) == false;
        }

        public static bool DoesNotContain<TItem>(this IEnumerable<TItem> enumerable, TItem objToVerify, IEqualityComparer<TItem> comparer)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            comparer.ThrowIfArgumentNull(nameof(comparer));

            return enumerable.Contains_(objToVerify, comparer) == false;
        }

        public static bool DoesNotContain<TItem, TObj>(this IEnumerable<TItem> enumerable, TObj objToVerify, Func<TObj, TItem, bool> comparison)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            comparison.ThrowIfArgumentNull(nameof(comparison));

            return enumerable.Contains_(objToVerify, comparison) == false;
        }

        public static bool Contains<TItem, TObj>(this IEnumerable<TItem> enumerable, TObj objToVerify, Func<TObj, TItem, bool> comparison)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            comparison.ThrowIfArgumentNull(nameof(comparison));

            return enumerable.Contains_(objToVerify, comparison);
        }

        #endregion //Public methods

        #region " Private methods "

        private static bool Contains_<TItem, TObj>(this IEnumerable<TItem> enumerable, TObj objToVerify) where TObj : TItem
        {
            return enumerable.Contains(objToVerify);
        }

        private static bool Contains_<TItem>(this IEnumerable<TItem> enumerable, TItem objToVerify, IEqualityComparer<TItem> comparer)
        {
            return enumerable.Contains(objToVerify, comparer);
        }

        private static bool Contains_<TItem, TObj>(this IEnumerable<TItem> enumerable, TObj objToVerify, Func<TObj, TItem, bool> comparison)
        {
            return enumerable.Any(EqualsToObject);

            bool EqualsToObject(TItem i) => comparison(objToVerify, i);
        }

        #endregion //Private methods
    }
}
