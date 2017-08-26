using System;
using SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Interfaces;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions
{
    public static partial class ThrowExtensions
    {
        #region | Public methods |

        public static T ThrowIfNull<T>(this T obj, string message)
        {
            return obj.ThrowIfNull_(message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfNull<T>(this T obj, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIfNull_(buildMessage, (Func<string, T, Exception>)null);
        }

        /// <summary>
        /// Take an object and throw an exception created from it if the caller is null.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="obj">Object to create the exception with</param>
        /// <param name="createException">Action creating the exception to throw</param>
        /// <returns>The caller if the caller is not null. Else an exception of type TException is thrown</returns>
        public static T ThrowIfNull<T>(this T obj, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNull_((Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIfNull<T>(this T obj, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNull_(message, createException);
        }

        public static T ThrowIfNull<T>(this T obj, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNull_(buildMessage, createException);
        }

        #endregion //Public methods

        #region | Private methods |

        private static T ThrowIfNull_<T>(this T obj, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj == null, message, createException);
        }

        private static T ThrowIfNull_<T>(this T obj, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj == null, buildMessage, createException);
        }

        #endregion //Private methods
    }
}
