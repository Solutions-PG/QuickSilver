using System;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Fluent
{
    public static partial class ObjectExtensions
    {
        #region " Public methods "

        /// <summary>
        /// If the condition is true an action using the caller is executed, then the caller is returned.
        /// Useful in fluent scenario.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">The caller</param>
        /// <param name="condition">Delegate returning if the a condition has been met</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "condition" is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>The caller</returns>
        public static T ApplyIf<T>(this T obj, Func<T, bool> condition, Action<T> action)
        {
            condition.ThrowIfArgumentNull(nameof(condition));
            action.ThrowIfArgumentNull(nameof(action));

            return obj.ApplyIf_(condition(obj), action);
        }

        /// <summary>
        /// If the caller is not null an action using the caller is executed, then the caller is returned.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">The caller</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>The caller</returns>
        public static T ApplyIfNotNull<T>(this T obj, Action<T> action) => obj.ApplyIf_(obj != null, action.ThrowIfArgumentNull(nameof(action)));

        /// <summary>
        /// If the condition is true an action using the caller is executed, then the caller is returned.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">The caller</param>
        /// <param name="condition">Condition to determine if the action must be called</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>The caller</returns>
        public static T ApplyIf<T>(this T obj, bool condition, Action<T> action) => obj.ApplyIf_(condition, action.ThrowIfArgumentNull(nameof(action)));

        /// <summary>
        /// Execute an action on the caller or by using it then return the caller.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">The caller</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>The caller</returns>
        public static T Apply<T>(this T obj, Action<T> action) => obj.Apply_(action.ThrowIfArgumentNull(nameof(action)));

        #endregion //Public methods

        #region " Private methods "

        public static T ApplyIf_<T>(this T obj, bool condition, Action<T> action) { if (condition) { action(obj); } return obj; }
        public static T Apply_<T>(this T obj, Action<T> action) { action(obj); return obj; }

        #endregion //Private methods
    }
}
