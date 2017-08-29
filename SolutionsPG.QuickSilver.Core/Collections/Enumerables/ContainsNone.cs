using System;
using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region | Public methods |

        public static bool ContainsNone<T>(this IEnumerable<T> enumerable, params T[] objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAny_(objToVerify) == false;
        }

        public static bool ContainsNone<T>(this IEnumerable<T> enumerable, IEnumerable<T> objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAny_(objToVerify) == false;
        }

        public static bool ContainsNone<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> comparer, params T[] objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            comparer.ThrowIfArgumentNull(nameof(comparer));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAny_(comparer, objToVerify) == false;
        }

        public static bool ContainsNone<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> comparer, IEnumerable<T> objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));
            comparer.ThrowIfArgumentNull(nameof(comparer));

            return enumerable.ContainsAny_(comparer, objToVerify) == false;
        }

        public static bool ContainsNone<TSource, TObj>(this IEnumerable<TSource> enumerable, Func<TSource, TObj, bool> comparison, params TObj[] objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            comparison.ThrowIfArgumentNull(nameof(comparison));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));

            return enumerable.ContainsAny_(comparison, objToVerify) == false;
        }

        public static bool ContainsNone<TSource, TObj>(this IEnumerable<TSource> enumerable, Func<TSource, TObj, bool> comparison, IEnumerable<TObj> objToVerify)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            objToVerify.ThrowIfArgumentNull(nameof(objToVerify));
            comparison.ThrowIfArgumentNull(nameof(comparison));

            return enumerable.ContainsAny_(comparison, objToVerify) == false;
        }

        #endregion //Public methods
    }
}
