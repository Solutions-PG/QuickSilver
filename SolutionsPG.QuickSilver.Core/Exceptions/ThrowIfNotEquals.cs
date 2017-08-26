using System;
using System.Collections.Generic;
using SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Interfaces;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions
{
    public static partial class ThrowExtensions
    {
        #region | Public methods |

        public static T ThrowIfNotEquals<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, string message)
        {
            return obj.ThrowIfNotEquals_(otherObj, compareEquality, message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfNotEquals<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIfNotEquals_(otherObj, compareEquality, buildMessage, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfNotEquals<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNotEquals_(otherObj, compareEquality, (Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIfNotEquals<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNotEquals_(otherObj, compareEquality, message, createException);
        }

        public static T ThrowIfNotEquals<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNotEquals_(otherObj, compareEquality, buildMessage, createException);
        }

        public static T ThrowIfNotEquals<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, string message)
        {
            return obj.ThrowIfNotEquals_(otherObj, comparer, message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfNotEquals<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIfNotEquals_(otherObj, comparer, buildMessage, (Func<string, T, Exception>)null);
        }
        
        public static T ThrowIfNotEquals<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNotEquals_(otherObj, comparer, (Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIfNotEquals<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNotEquals_(otherObj, comparer, message, createException);
        }

        public static T ThrowIfNotEquals<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfNotEquals_(otherObj, comparer, buildMessage, createException);
        }

        public static T ThrowIfNotEquals<T>(this T obj, T otherObj, string message)
        {
            return obj.ThrowIfNotEquals_(otherObj, message, (Func<string, T, Exception>)null);
        }

        public static T ThrowIfNotEquals<T>(this T obj, T otherObj, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            return obj.ThrowIfNotEquals_(otherObj, buildMessage, (Func<string, T, Exception>)null);
        }
        
        public static T ThrowIfNotEquals<T>(this T obj, T otherObj, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfEquals_(otherObj, (Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static T ThrowIfNotEquals<T>(this T obj, T otherObj, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfEquals_(otherObj, message, createException);
        }

        public static T ThrowIfNotEquals<T>(this T obj, T otherObj, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIfEquals_(otherObj, buildMessage, createException);
        }

        #endregion //Public methods

        #region | Private methods |

        private static T ThrowIfNotEquals_<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.IsNot(otherObj, compareEquality), message, createException);
        }

        private static T ThrowIfNotEquals_<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.IsNot(otherObj, compareEquality), buildMessage, createException);
        }

        private static T ThrowIfNotEquals_<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.IsNot(otherObj, comparer), message, createException);
        }

        private static T ThrowIfNotEquals_<T>(this T obj, T otherObj, IEqualityComparer<T> comparer, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.IsNot(otherObj, comparer), buildMessage, createException);
        }

        private static T ThrowIfNotEquals_<T>(this T obj, T otherObj, string message, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.IsNot(otherObj), message, createException);
        }

        private static T ThrowIfNotEquals_<T>(this T obj, T otherObj, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            return obj.ThrowIf_(obj.IsNot(otherObj), buildMessage, createException);
        }

        #endregion //Private methods
    }
}
