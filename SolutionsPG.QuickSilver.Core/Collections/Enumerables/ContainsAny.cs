using System;
using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region | Public methods |

        public static bool ContainsAny<T>(this IEnumerable<T> source, params T[] others)
        {
            source.ThrowIfArgumentNull(nameof(source));
            others.ThrowIfArgumentNull(nameof(others));

            return source.ContainsAny_(others);
        }

        public static bool ContainsAny<T>(this IEnumerable<T> source, IEnumerable<T> others)
        {
            source.ThrowIfArgumentNull(nameof(source));
            others.ThrowIfArgumentNull(nameof(others));

            return source.ContainsAny_(others);
        }

        public static bool ContainsAny<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer, params T[] others)
        {
            source.ThrowIfArgumentNull(nameof(source));
            comparer.ThrowIfArgumentNull(nameof(comparer));
            others.ThrowIfArgumentNull(nameof(others));

            return source.ContainsAny_(comparer, others);
        }

        public static bool ContainsAny<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer, IEnumerable<T> others)
        {
            source.ThrowIfArgumentNull(nameof(source));
            others.ThrowIfArgumentNull(nameof(others));
            comparer.ThrowIfArgumentNull(nameof(comparer));

            return source.ContainsAny_(comparer, others);
        }

        public static bool ContainsAny<TSource, TOther>(this IEnumerable<TSource> source, Func<TSource, TOther, bool> areEquivalent, params TOther[] others)
        {
            source.ThrowIfArgumentNull(nameof(source));
            areEquivalent.ThrowIfArgumentNull(nameof(areEquivalent));
            others.ThrowIfArgumentNull(nameof(others));

            return source.ContainsAny_(areEquivalent, others);
        }

        public static bool ContainsAny<TSource, TOther>(this IEnumerable<TSource> source, Func<TSource, TOther, bool> areEquivalent, IEnumerable<TOther> others)
        {
            source.ThrowIfArgumentNull(nameof(source));
            others.ThrowIfArgumentNull(nameof(others));
            areEquivalent.ThrowIfArgumentNull(nameof(areEquivalent));

            return source.ContainsAny_(areEquivalent, others);
        }

        #endregion //Public methods

        #region | Private methods |

        private static bool ContainsAny_<T>(this IEnumerable<T> source, IEnumerable<T> others) => others.Any(CreateSourceContains(source));

        private static bool ContainsAny_<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer, IEnumerable<T> others) => others.Any(CreateSourceContains(source, comparer));

        private static bool ContainsAny_<TSource, TOther>(this IEnumerable<TSource> source, Func<TSource, TOther, bool> areEquivalent, IEnumerable<TOther> others) => others.Any(CreateSourceContains(source, areEquivalent));

        private static Func<T, bool> CreateSourceContains<T>(IEnumerable<T> source) => Memoize_(source).Contains;

        private static Func<T, bool> CreateSourceContains<T>(IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            ICollection<T> memoizedSource = Memoize_(source);

            bool SourceContains(T o) => memoizedSource.Contains(o, comparer);
            return SourceContains;
        }

        private static Func<TOther, bool> CreateSourceContains<TSource, TOther>(IEnumerable<TSource> source, Func<TSource, TOther, bool> areEquivalent)
        {
            ICollection<TSource> memoizedSource = Memoize_(source);

            bool SourceContains(TOther o)
            {
                bool AreEquivalent(TSource s) => areEquivalent(s, o);
                return memoizedSource.Any(AreEquivalent);
            }
            return SourceContains;
        }

        private static ICollection<T> Memoize_<T>(IEnumerable<T> source) => ((source as ICollection<T>) ?? source.Memoize());

        #endregion //Private methods
    }
}
