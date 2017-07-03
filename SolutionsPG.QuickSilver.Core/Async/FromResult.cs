using System;
using System.Threading.Tasks;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class AsyncExtensions
    {
        #region " Public methods "

        public static Task<T> FromResult<T>(Func<T> action)
        {
            action.ThrowIfArgumentNull(nameof(action));

            try
            {
                return Task.FromResult(action());
            }
            catch (Exception ex)
            {
                return Task.FromException<T>(ex);
            }
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
