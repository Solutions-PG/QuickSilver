using System;

namespace SolutionsPG.QuickSilver.Commons.Extensions
{
    public static partial class ObjectExtensions
    {
        #region " Public methods "

        /// <summary>
        /// Take an object and transform it into something else if the condition is met.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <typeparam name="TResult">Type of the returned objet</typeparam>
        /// <param name="obj">Object to transform</param>
        /// <param name="condition">Delegate returning if the a condition has been met</param>
        /// <param name="action">Action transforming the object</param>
        /// <returns>The object transformed if the condition is met. Else Default(TResult)</returns>
        public static TResult TransformIf<T, TResult>(this T obj, Func<T, bool> condition, Func<T, TResult> action)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return obj.TransformIf_(condition(obj), action);
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
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return obj.TransformIf_(condition, action);
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
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return obj.Transform_(action);
        }

        #endregion //Public methods

        #region " Private methods "

        private static TResult TransformIf_<T, TResult>(this T obj, bool condition, Func<T, TResult> action) => (condition) ? action(obj) : default(TResult);
        private static TResult Transform_<T, TResult>(this T obj, Func<T, TResult> action) => action(obj);

        #endregion //Private methods
    }
}
