using System;
using System.Threading.Tasks;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Async
{
    /// <summary>
    /// Contains extensions related to async operations
    /// </summary>
    public static class AsyncExtensions
    {
        #region " Public methods "

        /// <summary>
        /// Make it possible to handle exception with synchronous call to Task in a similar way to the asynchronous
        /// calls in that if an exception occur it is return as part of the returned Task.
        /// </summary>
        /// <typeparam name="T">Type of the result</typeparam>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>A Task{T} containing the result or the exception</returns>
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
    }
}
