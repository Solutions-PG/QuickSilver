using System;
using System.Collections.Generic;
using System.Linq;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool DoesNotContain<TItem>(this IEnumerable<TItem> source, TItem objToVerify)
        {
            source.ThrowIfArgumentNull(nameof(source));

            return source.Contains_(objToVerify) == false;
        }

        public static bool DoesNotContain<TItem>(this IEnumerable<TItem> source, TItem objToVerify, IEqualityComparer<TItem> comparer)
        {
            source.ThrowIfArgumentNull(nameof(source));
            comparer.ThrowIfArgumentNull(nameof(comparer));

            return source.Contains_(objToVerify, comparer) == false;
        }

        public static bool DoesNotContain<TItem, TObj>(this IEnumerable<TItem> source, TObj objToVerify, Func<TObj, TItem, bool> comparison)
        {
            source.ThrowIfArgumentNull(nameof(source));
            comparison.ThrowIfArgumentNull(nameof(comparison));

            return source.Contains_(objToVerify, comparison) == false;
        }

        public static bool Contains<TItem, TObj>(this IEnumerable<TItem> source, TObj objToVerify, Func<TObj, TItem, bool> comparison)
        {
            source.ThrowIfArgumentNull(nameof(source));
            comparison.ThrowIfArgumentNull(nameof(comparison));

            return source.Contains_(objToVerify, comparison);
        }

        #endregion //Public methods

        #region " Private methods "

        private static bool Contains_<TItem>(this IEnumerable<TItem> source, TItem objToVerify)
        {
            return source.Contains(objToVerify);
        }

        private static bool Contains_<TItem>(this IEnumerable<TItem> source, TItem objToVerify, IEqualityComparer<TItem> comparer)
        {
            return source.Contains(objToVerify, comparer);
        }

        private static bool Contains_<TItem, TObj>(this IEnumerable<TItem> source, TObj objToVerify, Func<TObj, TItem, bool> comparison)
        {
            bool EqualsToObject(TItem i) => comparison(objToVerify, i);
            return source.Any(EqualsToObject);
        }

        #endregion //Private methods
    }
}
