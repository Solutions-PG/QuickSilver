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

        public static bool One<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            predicate.ThrowIfArgumentNull(nameof(predicate));

            using (var enumerator = enumerable.GetEnumerator())
            {
                return (enumerator.MoveNext_(predicate) && !enumerator.MoveNext_(predicate));
            }
        }

        public static bool One<T>(this IEnumerable<T> enumerable)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));

            using (var enumerator = enumerable.GetEnumerator())
            {
                return (enumerator.MoveNext() && !enumerator.MoveNext());
            }
        }

        public static bool Exactly<T>(this IEnumerable<T> enumerable, int count, Func<T, bool> predicate)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            count.ThrowIfArgument(count < 1, nameof(count));

            using (var enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext_(predicate))
                {
                    if (--count == 0)
                        return !enumerator.MoveNext_(predicate);
                }
                return false;
            }
        }

        public static bool Exactly<T>(this IEnumerable<T> enumerable, int count)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            count.ThrowIfArgument(count < 1, nameof(count));

            using (var enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (--count == 0)
                        return !enumerator.MoveNext();
                }
                return false;
            }
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
