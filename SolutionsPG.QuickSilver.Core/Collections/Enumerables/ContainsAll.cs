using System;
using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region | Public methods |

        public static bool ContainsAll<T>(this IEnumerable<T> source, params T[] others)
        {
            source.ThrowIfArgumentNull(nameof(source));
            others.ThrowIfArgumentNull(nameof(others));

            return source.ContainsAll_(others);
        }

        public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> others)
        {
            source.ThrowIfArgumentNull(nameof(source));
            others.ThrowIfArgumentNull(nameof(others));

            return source.ContainsAll_(others);
        }

        public static bool ContainsAll<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer, params T[] others)
        {
            source.ThrowIfArgumentNull(nameof(source));
            comparer.ThrowIfArgumentNull(nameof(comparer));
            others.ThrowIfArgumentNull(nameof(others));

            return source.ContainsAll_(comparer, others);
        }

        public static bool ContainsAll<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer, IEnumerable<T> others)
        {
            source.ThrowIfArgumentNull(nameof(source));
            others.ThrowIfArgumentNull(nameof(others));
            comparer.ThrowIfArgumentNull(nameof(comparer));

            return source.ContainsAll_(comparer, others);
        }

        public static bool ContainsAll<TSource, TOther>(this IEnumerable<TSource> source, Func<TSource, TOther, bool> comparison, params TOther[] others)
        {
            source.ThrowIfArgumentNull(nameof(source));
            comparison.ThrowIfArgumentNull(nameof(comparison));
            others.ThrowIfArgumentNull(nameof(others));

            return source.ContainsAll_(comparison, others);
        }

        public static bool ContainsAll<TSource, TOther>(this IEnumerable<TSource> source, Func<TSource, TOther, bool> comparison, IEnumerable<TOther> others)
        {
            source.ThrowIfArgumentNull(nameof(source));
            others.ThrowIfArgumentNull(nameof(others));
            comparison.ThrowIfArgumentNull(nameof(comparison));

            return source.ContainsAll_(comparison, others);
        }

        #endregion //Public methods

        #region | Private methods |

        private static bool ContainsAll_<T>(this IEnumerable<T> source, IEnumerable<T> others) => others.All(CreateSourceContains(source));

        private static bool ContainsAll_<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer, IEnumerable<T> others) => others.All(CreateSourceContains(source, comparer));

        private static bool ContainsAll_<TSource, TOther>(this IEnumerable<TSource> source, Func<TSource, TOther, bool> areEquivalent, IEnumerable<TOther> others) => others.All(CreateSourceContains(source, areEquivalent));

        #endregion //Private methods
    }
}
