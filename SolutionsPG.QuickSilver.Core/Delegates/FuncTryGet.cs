using SolutionsPG.QuickSilver.Core.Exceptions;
using System;

namespace SolutionsPG.QuickSilver.Core.Delegates
{
    public delegate bool FuncTryGet<in T, TResult>(T obj, out TResult result);

    public static class FuncTryGetExtensions
    {
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

        public static FuncTryGet<T, TResult> CombineWith<T, TResult>(this FuncTryGet<T, TResult> tryGet, FuncTryGet<T, TResult> tryGetIfNotFound)
        {
            tryGet.ThrowIfArgumentNull(nameof(tryGet));
            tryGetIfNotFound.ThrowIfArgumentNull(nameof(tryGetIfNotFound));

            return CombinedTryGetValue;

            bool CombinedTryGetValue(T t, out TResult result)
            {
                return tryGet(t, out result) || tryGetIfNotFound(t, out result);
            }
        }

        private static FuncTryGet<T, TResult> AsFuncTryGet_<T, TResult>(this Func<T, TResult> action, bool returnValue)
        {
            return FuncTryGetWrapper;

            bool FuncTryGetWrapper(T t, out TResult result)
            {
                result = action(t);
                return returnValue;
            }
        }
    }
}
