using SolutionsPG.QuickSilver.Core.Exceptions;
using System;

namespace SolutionsPG.QuickSilver.Core.Delegates
{
    public delegate bool FuncTryGet<in T, TResult>(T obj, out TResult result);

    public static partial class DelegateExtensions
    {
        #region " Public methods "

        public static FuncTryGet<T, TResult> AsFuncTryGet<T, TResult>(this Func<T, TResult> action)
        {
            action.ThrowIfArgumentNull(nameof(action));

            return action.AsFuncTryGet_(true);
        }

        public static FuncTryGet<T, TResult> AsFuncTryGet<T, TResult>(this Func<T, TResult> action, bool returnValue)
        {
            action.ThrowIfArgumentNull(nameof(action));

            return action.AsFuncTryGet_(returnValue);
        }

        #endregion //Public methods

        #region " Private methods "

        private static FuncTryGet<T, TResult> AsFuncTryGet_<T, TResult>(this Func<T, TResult> action, bool returnValue)
        {
            return FuncTryGetWrapper;

            bool FuncTryGetWrapper(T t, out TResult result)
            {
                result = action(t);
                return returnValue;
            }
        }

        #endregion //Private methods
    }
}
