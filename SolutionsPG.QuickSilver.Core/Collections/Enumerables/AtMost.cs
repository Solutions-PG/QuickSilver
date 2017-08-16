using System;
using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool AtMostOne<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            predicate.ThrowIfArgumentNull(nameof(predicate));

            using (var enumerator = enumerable.GetEnumerator())
            {
                return (!enumerator.MoveNext_(predicate) || !enumerator.MoveNext(predicate));
            }
        }

        public static bool AtMostOne<T>(this IEnumerable<T> enumerable)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));

            using (var enumerator = enumerable.GetEnumerator())
            {
                return (!enumerator.MoveNext() || !enumerator.MoveNext());
            }
        }

        public static bool AtMost<T>(this IEnumerable<T> enumerable, int maximumCount, Func<T, bool> predicate)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            maximumCount.ThrowIfArgument(maximumCount < 1, nameof(maximumCount));
            predicate.ThrowIfArgumentNull(nameof(predicate));

            using (var enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext_(predicate))
                {
                    if (--maximumCount == 0)
                        return !enumerator.MoveNext_(predicate);
                }
                return true;
            }
        }

        public static bool AtMost<T>(this IEnumerable<T> enumerable, int maximumCount)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            maximumCount.ThrowIfArgument(maximumCount < 1, nameof(maximumCount));

            using (var enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (--maximumCount == 0)
                        return !enumerator.MoveNext();
                }
                return true;
            }
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
