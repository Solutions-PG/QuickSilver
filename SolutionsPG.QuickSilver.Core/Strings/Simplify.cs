using System.Text;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Strings
{
    public static partial class StringExtensions
    {
        #region " Public methods "

        public static string Simplify(this string str)
        {
            str.ThrowIfArgumentNullOrWhiteSpace(nameof(str));

            return Encoding.UTF8.GetString(Encoding.GetEncoding("ISO-8859-8").GetBytes(str.ToUpper()));
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
