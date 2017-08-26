using System;
using System.Collections.Generic;
using SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Interfaces;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions
{
    public static partial class ThrowExtensions
    {
        #region | Public methods |

        public static T ThrowIfDefault<T>(this T obj, string message)
        {
            return obj.ThrowIfDefault_(message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfDefault<T>(this T obj, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIfDefault_(buildMessage, (Func<string, T, Exception>)null);
        }
        
        public static T ThrowIfDefault<T>(this T obj, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfDefault_((Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIfDefault<T>(this T obj, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfDefault_(message, createException);
        }

        public static T ThrowIfDefault<T>(this T obj, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfDefault_(buildMessage, createException);
        }

        #endregion //Public methods

        #region | Private methods |

        private static T ThrowIfDefault_<T>(this T obj, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.IsDefault(), message, createException);
        }

        private static T ThrowIfDefault_<T>(this T obj, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.IsDefault(), buildMessage, createException);
        }

        #endregion //Private methods
    }
}
