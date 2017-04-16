using System;

namespace SolutionsPG.QuickSilver.Commons.Extensions
{
    public static partial class ObjectExtensions
    {
        #region " Public methods "

        /// <summary>
        /// Take an object and throw an exception created from it if the condition is met. Useful in fluent scenario.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <typeparam name="TException">Type of the exception to throw if the condition is met</typeparam>
        /// <param name="obj">Object to create the exception with</param>
        /// <param name="condition">Delegate returning if a condition has been met</param>
        /// <param name="createException">Action creating the exception to throw</param>
        /// <returns>The caller if the condition hasn't been met. Else an exception of type TException is thrown</returns>
        public static T ThrowIf<T, TException>(this T obj, Func<T, bool> condition, Func<T, TException> createException) where TException : Exception
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (createException == null)
                throw new ArgumentNullException(nameof(createException));

            return obj.ThrowIf_(condition(obj), createException);
        }

        /// <summary>
        /// Take an object and throw an exception created from it if the caller is null.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <typeparam name="TException">Type of the exception to throw if the caller is null</typeparam>
        /// <param name="obj">Object to create the exception with</param>
        /// <param name="createException">Action creating the exception to throw</param>
        /// <returns>The caller if the caller is not null. Else an exception of type TException is thrown</returns>
        public static T ThrowIfNull<T, TException>(this T obj, Func<T, TException> createException) where TException : Exception
        {
            if (createException == null)
                throw new ArgumentNullException(nameof(createException));

            return obj.ThrowIf_(obj == null, createException);
        }

        /// <summary>
        /// Take an object and throw an exception created from it if the condition is met.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <typeparam name="TException">Type of the exception to throw if the condition is met</typeparam>
        /// <param name="obj">Object to create the exception with</param>
        /// <param name="condition">Condition to meet to throw the exception</param>
        /// <param name="createException">Action creating the exception to throw</param>
        /// <returns>The caller if the condition hasn't been met. Else an exception of type TException is thrown</returns>
        public static T ThrowIf<T, TException>(this T obj, bool condition, Func<T, TException> createException) where TException : Exception
        {
            if (createException == null)
                throw new ArgumentNullException(nameof(createException));

            return obj.ThrowIf_(condition, createException);
        }

        /// <summary>
        /// Take an object and throw an exception created from it.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <typeparam name="TException">Type of the exception to throw</typeparam>
        /// <param name="obj">Object to create the exception with</param>
        /// <param name="createException">Action creating the exception to throw</param>
        public static void Throw<T, TException>(this T obj, Func<T, TException> createException) where TException : Exception
        {
            if (createException == null)
                throw new ArgumentNullException(nameof(createException));

            obj.Throw_(createException);
        }

        #endregion //Public methods

        #region " Private methods "

        private static T ThrowIf_<T, TException>(this T obj, bool condition, Func<T, TException> createException) where TException : Exception
        {
            return (condition) ? throw createException(obj) : obj;
        }

        private static void Throw_<T, TException>(this T obj, Func<T, TException> createException) where TException : Exception
        {
            throw createException(obj);
        }

        #endregion //Private methods
    }
}
