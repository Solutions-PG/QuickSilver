using System;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Fluent
{
    public static partial class ObjectExtensions
    {
        #region " Public methods "

        /// <summary>
        /// Take an object and transform it into something else if the condition is met. Useful in fluent scenario.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <typeparam name="TResult">Type of the returned objet</typeparam>
        /// <param name="obj">Object to transform</param>
        /// <param name="condition">Delegate returning if a condition has been met</param>
        /// <param name="action">Action transforming the object</param>
        /// <returns>The object transformed if the condition is met. Else Default(TResult)</returns>
        public static TResult TransformIf<T, TResult>(this T obj, Func<T, bool> condition, Func<T, TResult> action)
        {
            condition.ThrowIfArgumentNull(nameof(condition));
            action.ThrowIfArgumentNull(nameof(action));

            return obj.TransformIf_(condition(obj), action);
        }

        /// <summary>
        /// Take an object and transform it into the same or similar type if the condition is met. Useful in fluent scenario.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <typeparam name="TResult">Type of the returned objet</typeparam>
        /// <param name="obj">Object to transform</param>
        /// <param name="condition">Delegate returning if a condition has been met</param>
        /// <param name="action">Action transforming the object</param>
        /// <returns>The object transformed, if the condition is met. Else, the caller.</returns>
        public static TResult TransformIfOrSelf<T, TResult>(this T obj, Func<T, bool> condition, Func<T, TResult> action) where T : TResult
        {
            condition.ThrowIfArgumentNull(nameof(condition));
            action.ThrowIfArgumentNull(nameof(action));

            return obj.TransformIfOrSelf_(condition(obj), action);
        }

        /// <summary>
        /// Take an object and transform it into something else if the caller is not null.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <typeparam name="TResult">Type of the returned objet</typeparam>
        /// <param name="obj">Object to transform</param>
        /// <param name="action">Action transforming the object</param>
        /// <returns>The object transformed if the caller is not null. Else Default(TResult)</returns>
        public static TResult TransformIfNotNull<T, TResult>(this T obj, Func<T, TResult> action)
        {
            return obj.TransformIf_(obj != null, action.ThrowIfArgumentNull(nameof(action)));
        }

        /// <summary>
        /// Take an object and transform it into something else if the condition is met.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <typeparam name="TResult">Type of the returned objet</typeparam>
        /// <param name="obj">Object to transform</param>
        /// <param name="condition">Condition to meet to transform the object</param>
        /// <param name="action">Action transforming the object</param>
        /// <returns>The object transformed if the condition is met. Else Default(TResult)</returns>
        public static TResult TransformIf<T, TResult>(this T obj, bool condition, Func<T, TResult> action)
        {
            return obj.TransformIf_(condition, action.ThrowIfArgumentNull(nameof(action)));
        }

        /// <summary>
        /// Take an object and transform it into the same or similar type if the condition is met.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <typeparam name="TResult">Type of the returned objet</typeparam>
        /// <param name="obj">Object to transform</param>
        /// <param name="condition">Condition to meet to transform the object</param>
        /// <param name="action">Action transforming the object</param>
        /// <returns>The object transformed, if the condition is met. Else, the caller.</returns>
        public static TResult TransformIfOrSelf<T, TResult>(this T obj, bool condition, Func<T, TResult> action) where T : TResult
        {
            return obj.TransformIfOrSelf_(condition, action.ThrowIfArgumentNull(nameof(action)));
        }

        /// <summary>
        /// Take an object and transform it into something else.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <typeparam name="TResult">Type of the returned objet</typeparam>
        /// <param name="obj">Object to transform</param>
        /// <param name="action">Action transforming the object</param>
        /// <returns>The object transformed</returns>
        public static TResult Transform<T, TResult>(this T obj, Func<T, TResult> action)
        {
            return obj.Transform_(action.ThrowIfArgumentNull(nameof(action)));
        }

        #endregion //Public methods

        #region " Private methods "

        private static TResult TransformIfOrSelf_<T, TResult>(this T obj, bool condition, Func<T, TResult> action) where T : TResult => (condition) ? action(obj) : obj;
        private static TResult TransformIf_<T, TResult>(this T obj, bool condition, Func<T, TResult> action) => (condition) ? action(obj) : default(TResult);
        private static TResult Transform_<T, TResult>(this T obj, Func<T, TResult> action) => action(obj);

        #endregion //Private methods
    }
}
