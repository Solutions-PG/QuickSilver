using System;
using SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Interfaces;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions
{
    public static partial class ThrowExtensions
    {
        #region | Public methods |

        public static T ThrowIf<T>(this T obj, Func<T, bool> condition, string message)
        {
            return obj.ThrowIf_(condition, message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIf<T>(this T obj, Func<T, bool> condition, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIf_(condition, buildMessage, (Func<string, T, Exception>)null);
        }

        public static T ThrowIf<T>(this T obj, Func<T, bool> condition, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(condition, (Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIf<T>(this T obj, Func<T, bool> condition, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(condition.DoEvaluateCondition(obj), message, createException);
        }

        public static T ThrowIf<T>(this T obj, Func<T, bool> condition, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(condition.DoEvaluateCondition(obj), buildMessage, createException);
        }

        public static T ThrowIf<T>(this T obj, bool condition, string message)
        {
            return obj.ThrowIf_(condition, message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIf<T>(this T obj, bool condition, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIf_(condition, buildMessage, (Func<string, T, Exception>)null);
        }

        public static T ThrowIf<T>(this T obj, bool condition, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(condition, (Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIf<T>(this T obj, bool condition, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(condition, message, createException);
        }

        public static T ThrowIf<T>(this T obj, bool condition, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(condition, buildMessage, createException);
        }

        #endregion //Public methods

        #region | Private methods |

        private static T ThrowIf_<T>(this T obj, Func<T, bool> condition, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(condition.DoEvaluateCondition(obj), message, createException);
        }

        private static T ThrowIf_<T>(this T obj, Func<T, bool> condition, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(condition.DoEvaluateCondition(obj), buildMessage, createException);
        }

        private static T ThrowIf_<T>(this T obj, bool condition, string message, Func<string, T, Exception> createException)
        {
            if (condition)
                obj.Throw_(message, createException);
            return obj;
        }

        private static T ThrowIf_<T>(this T obj, bool condition, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            if (condition)
                obj.Throw_(buildMessage, createException);
            return obj;
        }

        private static bool DoEvaluateCondition<T>(this Func<T, bool> condition, T obj)
        {
            try
            {
                //condition.ThrowIfArgumentNull_(nameof(condition));
                return condition(obj);
            }
            catch (Exception e)
            {
                throw e.CreateInternalException_("Condition excecution failed", obj);
            }
        }

        #endregion //Private methods
    }
}
