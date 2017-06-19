using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool AtMost<T, TResult>(this IEnumerable<T> enumerable, int maximumCount) => !enumerable.ThrowIfArgumentNull(nameof(enumerable)).Skip(maximumCount).Any();

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
