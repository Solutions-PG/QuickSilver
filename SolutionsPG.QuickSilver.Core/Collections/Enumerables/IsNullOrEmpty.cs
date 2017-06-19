using System.Collections.Generic;
using System.Linq;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool IsNullOrEmpty<T, TResult>(this IEnumerable<T> enumerable) => (enumerable == null) || (!enumerable.Any());

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
