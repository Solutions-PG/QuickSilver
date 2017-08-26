using System;
using SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Interfaces;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions
{
    public static partial class ThrowExtensions
    {
        #region | Public methods |

        public static T ThrowIfNot<T>(this T obj, Func<T, bool> condition, string message)
        {
            return obj.ThrowIfNot_(condition, message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfNot<T>(this T obj, Func<T, bool> condition, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIfNot_(condition, buildMessage, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfNot<T>(this T obj, Func<T, bool> condition, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNot_(condition, (Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIfNot<T>(this T obj, Func<T, bool> condition, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNot_(condition.DoEvaluateCondition(obj), message, createException);
        }

        public static T ThrowIfNot<T>(this T obj, Func<T, bool> condition, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNot_(condition.DoEvaluateCondition(obj), buildMessage, createException);
        }

        public static T ThrowIfNot<T>(this T obj, bool condition, string message)
        {
            return obj.ThrowIfNot_(condition, message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfNot<T>(this T obj, bool condition, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIfNot_(condition, buildMessage, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfNot<T>(this T obj, bool condition, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNot_(condition, (Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIfNot<T>(this T obj, bool condition, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNot_(condition, message, createException);
        }

        public static T ThrowIfNot<T>(this T obj, bool condition, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNot_(condition, buildMessage, createException);
        }

        #endregion //Public methods

        #region | Private methods |

        private static T ThrowIfNot_<T>(this T obj, Func<T, bool> condition, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(condition.DoEvaluateCondition(obj) == false, message, createException);
        }

        private static T ThrowIfNot_<T>(this T obj, Func<T, bool> condition, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(condition.DoEvaluateCondition(obj) == false, buildMessage, createException);
        }

        private static T ThrowIfNot_<T>(this T obj, bool condition, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(condition == false, message, createException);
        }

        private static T ThrowIfNot_<T>(this T obj, bool condition, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(condition == false, buildMessage, createException);
        }

        #endregion //Private methods
    }
}
