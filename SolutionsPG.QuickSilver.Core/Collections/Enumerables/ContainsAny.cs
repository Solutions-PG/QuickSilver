using System;
using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region | Public methods |

        public static bool ContainsAny<TItem>(this IEnumerable<TItem> enumerable, params TItem[] objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAny_(objToVerify);
        }

        public static bool ContainsAny<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAny_(objToVerify);
        }

        public static bool ContainsAny<TItem>(this IEnumerable<TItem> enumerable, IEqualityComparer<TItem> comparer, params TItem[] objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            comparer.ThrowIfArgumentNull(nameof(comparer));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAny_(objToVerify, comparer);
        }

        public static bool ContainsAny<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> objToVerify, IEqualityComparer<TItem> comparer)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));
            comparer.ThrowIfArgumentNull(nameof(comparer));

            return enumerable.ContainsAny_(objToVerify, comparer);
        }

        public static bool ContainsAny<TItem, TObj>(this IEnumerable<TItem> enumerable, Func<TObj, TItem, bool> comparison, params TObj[] objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            comparison.ThrowIfArgumentNull(nameof(comparison));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAny_(objToVerify, comparison);
        }

        public static bool ContainsAny<TItem, TObj>(this IEnumerable<TItem> enumerable, IEnumerable<TObj> objToVerify, Func<TObj, TItem, bool> comparison)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));
            comparison.ThrowIfArgumentNull(nameof(comparison));

            return enumerable.ContainsAny_(objToVerify, comparison);
        }

        #endregion //Public methods

        #region | Private methods |

        private static bool ContainsAny_<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> objToVerify)
        {
            IEnumerable<TItem> memoizedEnumerable = (enumerable as ICollection<TItem>) ?? enumerable.Memoize();

            bool EnumerableContainsObject(TItem o) => memoizedEnumerable.Contains(o);
            return objToVerify.Any(EnumerableContainsObject);
        }

        private static bool ContainsAny_<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> objToVerify, IEqualityComparer<TItem> comparer)
        {
            ICollection<TItem> memoizedEnumerable = (enumerable as ICollection<TItem>) ?? enumerable.Memoize();

            bool EnumerableContainsObject(TItem o) => memoizedEnumerable.Contains(o, comparer);
            return objToVerify.Any(EnumerableContainsObject);
        }

        private static bool ContainsAny_<TItem, TObj>(this IEnumerable<TItem> enumerable, IEnumerable<TObj> objToVerify, Func<TObj, TItem, bool> comparison)
        {
            ICollection<TItem> memoizedEnumerable = (enumerable as ICollection<TItem>) ?? enumerable.Memoize();
            
            bool EnumerableContainsObject(TObj o)
            {
                bool Compare(TItem i) => comparison(o, i);
                return memoizedEnumerable.Any(Compare);
            }
            return objToVerify.Any(EnumerableContainsObject);
        }

        #endregion //Private methods
    }
}
