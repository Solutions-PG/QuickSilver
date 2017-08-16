using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            if (enumerable == null)
                return true;

            using (var enumerator = enumerable.GetEnumerator())
                return !enumerator.MoveNext_(predicate);
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return true;

            using (var enumerator = enumerable.GetEnumerator())
                return !enumerator.MoveNext();
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
