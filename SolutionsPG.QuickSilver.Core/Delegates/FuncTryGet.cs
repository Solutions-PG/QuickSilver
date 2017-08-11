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

            return new FuncTryGetCombinator<T, TResult>(tryGet, tryGetIfNotFound).TryGetValue;
        }

        private static FuncTryGet<T, TResult> AsFuncTryGet_<T, TResult>(this Func<T, TResult> action, bool returnValue)
        {
            return new FuncTryGetWrapper<T, TResult>(action, returnValue).TryGetValue;
        }
    }

    internal struct FuncTryGetWrapper<T, TResult>
    {
        private readonly Func<T, TResult> _action;
        private readonly bool _returnValue;

        public FuncTryGetWrapper(Func<T, TResult> action, bool returnValue)
        {
            _action = action;
            _returnValue = returnValue;
        }

        public bool TryGetValue(T t, out TResult result)
        {
            result = _action(t);
            return _returnValue;
        }
    }

    internal struct FuncTryGetCombinator<T, TResult>
    {
        private readonly FuncTryGet<T, TResult> _tryGet;
        private readonly FuncTryGet<T, TResult> _tryGetIfNotFound;

        public FuncTryGetCombinator(FuncTryGet<T, TResult> tryGet, FuncTryGet<T, TResult> tryGetIfNotFound)
        {
            _tryGet = tryGet;
            _tryGetIfNotFound = tryGetIfNotFound;
        }

        public bool TryGetValue(T t, out TResult result)
        {
            return _tryGet(t, out result) || _tryGetIfNotFound(t, out result);
        }
    }
}
