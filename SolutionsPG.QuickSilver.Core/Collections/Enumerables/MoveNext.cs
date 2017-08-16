using System;
using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        private static bool MoveNext<T>(this IEnumerator<T> enumerator, Func<T, bool> predicate)
        {
            enumerator.ThrowIfArgumentNull(nameof(enumerator));
            predicate.ThrowIfArgumentNull(nameof(predicate));

            return enumerator.MoveNext_(predicate);
        }

        #endregion //Public methods

        #region " Private methods "

        private static bool MoveNext_<T>(this IEnumerator<T> enumerator, Func<T, bool> predicate)
        {
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion //Private methods
    }
}
