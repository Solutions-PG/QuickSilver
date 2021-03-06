﻿using System;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Fluent
{
    public static partial class ObjectExtensions
    {
        #region " Public methods "

        /// <summary>
        /// Execute an action if the condition is true and return the caller.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">The caller</param>
        /// <param name="condition">Condition to determine if the action must be called</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "condition" is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>The caller</returns>
        public static T DoIf<T>(this T obj, Func<T, bool> condition, Action action)
        {
            condition.ThrowIfArgumentNull(nameof(condition));
            action.ThrowIfArgumentNull(nameof(action));

            return obj.DoIf_(condition(obj), action);
        }

        /// <summary>
        /// Execute an action if the caller is not null and return the caller.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">The caller</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>The caller</returns>
        public static T DoIfNotNull<T>(this T obj, Action action) => obj.DoIf_(obj != null, action.ThrowIfArgumentNull(nameof(action)));

        /// <summary>
        /// Execute an action if the condition is true and return the caller.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">The caller</param>
        /// <param name="condition">Condition to determine if the action must be called</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>The caller</returns>
        public static T DoIf<T>(this T obj, bool condition, Action action) => obj.DoIf_(condition, action.ThrowIfArgumentNull(nameof(action)));

        /// <summary>
        /// Execute an action and return the caller.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">The caller</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>The caller</returns>
        public static T Do<T>(this T obj, Action action) => obj.Do_(action.ThrowIfArgumentNull(nameof(action)));

        #endregion //Public methods

        #region " Private methods "

        private static T DoIf_<T>(this T obj, bool condition, Action action) { if (condition) { action(); } return obj; }
        private static T Do_<T>(this T obj, Action action) { action(); return obj; }

        #endregion //Private methods
    }
}
