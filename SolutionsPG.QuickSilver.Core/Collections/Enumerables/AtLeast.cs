using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool AtLeast<T, TResult>(this IEnumerable<T> enumerable, int minimumCount) => enumerable.ThrowIfArgumentNull(nameof(enumerable)).Skip(minimumCount - 1).Any();

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
