using SolutionsPG.QuickSilver.Core.Exceptions;
using System.Text;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class StringExtensions
    {
        #region " Public methods "

        public static StringBuilder AsMutable(this string str) => new StringBuilder(str.ThrowIfArgumentNull(nameof(str)));

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
