using System.Collections.Generic;
using System.Linq;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class StringExtensions
    {
        #region " Public methods "

        public static bool IsNullOrEmpty<T, TResult>(this string str) => string.IsNullOrEmpty(str);
        public static bool IsNullOrWhiteSpace<T, TResult>(this string str) => string.IsNullOrWhiteSpace(str);

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
