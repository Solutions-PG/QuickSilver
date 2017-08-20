using System;
using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Exceptions;
using SolutionsPG.QuickSilver.Core.Fluent;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "
        
        public static bool AtLeastTwo<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            predicate.ThrowIfArgumentNull(nameof(predicate));

            using (var enumerator = enumerable.GetEnumerator())
            {
                return (enumerator.MoveNextWhere_(predicate) && enumerator.MoveNextWhere_(predicate));
            }
        }

        public static bool AtLeastTwo<T>(this IEnumerable<T> enumerable)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));

            using (var enumerator = enumerable.GetEnumerator())
            {
                return (enumerator.MoveNext() && enumerator.MoveNext());
            }
        }

        public static bool AtLeast<T>(this IEnumerable<T> enumerable, int minimumCount, Func<T, bool> predicate)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            minimumCount.ThrowIfArgument(minimumCount < 1, nameof(minimumCount));
            predicate.ThrowIfArgumentNull(nameof(predicate));

            using (var enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNextWhere_(predicate))
                {
                    if (--minimumCount == 0)
                        return true;
                }
                return false;
            }
        }

        public static bool AtLeast<T>(this IEnumerable<T> enumerable, int minimumCount)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            minimumCount.ThrowIfArgument(minimumCount < 1, nameof(minimumCount));

            using (var enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (--minimumCount == 0)
                        return true;
                }
                return false;
            }
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
