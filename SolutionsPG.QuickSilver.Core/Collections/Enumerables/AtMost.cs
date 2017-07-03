﻿using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool AtMost<T, TResult>(this IEnumerable<T> enumerable, int maximumCount)
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
