using System;
using System.Collections.Generic;
using SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Interfaces;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions
{
    public static partial class ThrowExtensions
    {
        #region | Public methods |

        public static T ThrowIfEquals<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, string message)
        {
            return obj.ThrowIfEquals_(otherObj, compareEquality, message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfEquals<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIfEquals_(otherObj, compareEquality, buildMessage, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfEquals<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfEquals_(otherObj, compareEquality, (Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIfEquals<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfEquals_(otherObj, compareEquality, message, createException);
        }

        public static T ThrowIfEquals<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfEquals_(otherObj, compareEquality, buildMessage, createException);
        }

        public static T ThrowIfEquals<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, string message)
        {
            return obj.ThrowIfEquals_(otherObj, comparer, message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfEquals<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIfEquals_(otherObj, comparer, buildMessage, (Func<string, T, Exception>)null);
        }
        
        public static T ThrowIfEquals<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfEquals_(otherObj, comparer, (Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIfEquals<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfEquals_(otherObj, comparer, message, createException);
        }

        public static T ThrowIfEquals<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfEquals_(otherObj, comparer, buildMessage, createException);
        }

        public static T ThrowIfEquals<T>(this T obj, T otherObj, string message)
        {
            return obj.ThrowIfEquals_(otherObj, message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfEquals<T>(this T obj, T otherObj, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIfEquals_(otherObj, buildMessage, (Func<string, T, Exception>)null);
        }

        /// <summary>
        /// Take an object and throw an exception created from it if the condition is met.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="obj">Object to create the exception with</param>
        /// <param name="otherObj">Another object to compare the original objec with</param>
        /// <param name="createException">Action creating the exception to throw</param>
        /// <returns>The caller if the condition hasn't been met. Else an exception of type TException is thrown</returns>
        public static T ThrowIfEquals<T>(this T obj, T otherObj, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfEquals_(otherObj, (Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIfEquals<T>(this T obj, T otherObj, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfEquals_(otherObj, message, createException);
        }

        public static T ThrowIfEquals<T>(this T obj, T otherObj, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfEquals_(otherObj, buildMessage, createException);
        }

        #endregion //Public methods

        #region | Private methods |

        private static T ThrowIfEquals_<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.Is(otherObj, compareEquality), message, createException);
        }

        private static T ThrowIfEquals_<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.Is(otherObj, compareEquality), buildMessage, createException);
        }

        private static T ThrowIfEquals_<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.Is(otherObj, comparer), message, createException);
        }

        private static T ThrowIfEquals_<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.Is(otherObj, comparer), buildMessage, createException);
        }

        private static T ThrowIfEquals_<T>(this T obj, T otherObj, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.Is(otherObj), message, createException);
        }

        private static T ThrowIfEquals_<T>(this T obj, T otherObj, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.Is(otherObj), buildMessage, createException);
        }

        #endregion //Private methods
    }
}
