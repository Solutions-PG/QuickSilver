using SolutionsPG.QuickSilver.Core.Exceptions;
using System;

namespace SolutionsPG.QuickSilver.Core.Delegates
{
    public static class DelegateExtensions
    {
        #region " Public methods "

        public static Func<T, TResult> CombineSelector<T, TMiddle, TResult>(this Func<T, TMiddle> first, Func<TMiddle, TResult> second)
        {
            first.ThrowIfArgumentNull(nameof(first));
            second.ThrowIfArgumentNull(nameof(second));

            return CombinedSelector;

            TResult CombinedSelector(T obj) => second(first(obj));
        }

        public static Func<T, bool> CombinePredicate<T>(this Func<T, bool> first, Func<T, bool> second)
        {
            first.ThrowIfArgumentNull(nameof(first));
            second.ThrowIfArgumentNull(nameof(second));

            return CombinedPredicate;

            bool CombinedPredicate(T obj) => first(obj) && second(obj);
        }

        public static Func<T, bool> CombinePredicateOr<T>(this Func<T, bool> first, Func<T, bool> second)
        {
            first.ThrowIfArgumentNull(nameof(first));
            second.ThrowIfArgumentNull(nameof(second));

            return CombinedPredicateOr;

            bool CombinedPredicateOr(T obj) => first(obj) || second(obj);
        }

        public static FuncTryGet<T, TResult> CombineTryGet<T, TResult>(this FuncTryGet<T, TResult> tryGet, FuncTryGet<T, TResult> fallback)
        {
            tryGet.ThrowIfArgumentNull(nameof(tryGet));
            fallback.ThrowIfArgumentNull(nameof(fallback));

            return CombinedTryGetValue;

            bool CombinedTryGetValue(T t, out TResult result) => tryGet(t, out result) || fallback(t, out result);
        }

        #endregion //Public methods
    }
}
