using System;
using SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Interfaces;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions
{
    public static partial class ThrowExtensions
    {
        #region | Public methods |

        public static T ThrowIfNotNull<T>(this T obj, string message)
        {
            return obj.ThrowIfNotNull_(message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfNotNull<T>(this T obj, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIfNotNull_(buildMessage, (Func<string, T, Exception>)null);
        }
        
        public static T ThrowIfNotNull<T>(this T obj, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNotNull_((Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIfNotNull<T>(this T obj, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNotNull_(message, createException);
        }

        public static T ThrowIfNotNull<T>(this T obj, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNotNull_(buildMessage, createException);
        }

        #endregion //Public methods

        #region | Private methods |

        private static T ThrowIfNotNull_<T>(this T obj, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj != null, message, createException);
        }

        private static T ThrowIfNotNull_<T>(this T obj, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj != null, buildMessage, createException);
        }

        #endregion //Private methods
    }
}
