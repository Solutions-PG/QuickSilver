using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Delegates;
using SolutionsPG.QuickSilver.Core.Exceptions;
using System;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static IEnumerable<TResult> SelectTryGet<T, TResult>(this IEnumerable<T> enumerable, Dictionary<T, TResult> dictionary)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            dictionary.ThrowIfArgumentNull(nameof(dictionary));

            return SelectTryGetIterator<T, TResult>(enumerable, dictionary.TryGetValue);
        }

        public static IEnumerable<TResult> SelectTryGet<T, TKey, TResult>(this IEnumerable<T> enumerable, Dictionary<TKey, TResult> dictionary, Func<T, TKey> keySelector)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            keySelector.ThrowIfArgumentNull(nameof(keySelector));

            return SelectTryGetIterator<T, TKey, TResult>(enumerable, keySelector, dictionary.TryGetValue);
        }

        public static IEnumerable<TResult> SelectTryGet<T, TElement, TResult>(this IEnumerable<T> enumerable, Dictionary<T, TElement> dictionary, Func<TElement, TResult> resultSelector)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            resultSelector.ThrowIfArgumentNull(nameof(resultSelector));

            return SelectTryGetIterator(enumerable, dictionary.TryGetValue, resultSelector);
        }

        public static IEnumerable<TResult> SelectTryGet<T, TKey, TElement, TResult>(this IEnumerable<T> enumerable, Dictionary<TKey, TElement> dictionary, Func<T, TKey> keySelector, Func<TElement, TResult> resultSelector)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            keySelector.ThrowIfArgumentNull(nameof(keySelector));
            resultSelector.ThrowIfArgumentNull(nameof(resultSelector));

            return SelectTryGetIterator(enumerable, keySelector, dictionary.TryGetValue, resultSelector);
        }

        public static IEnumerable<TResult> SelectTryGet<T, TResult>(this IEnumerable<T> enumerable, FuncTryGet<T, TResult> tryGet)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            tryGet.ThrowIfArgumentNull(nameof(tryGet));

            return SelectTryGetIterator(enumerable, tryGet);
        }

        #endregion //Public methods

        #region " Private methods "

        public static IEnumerable<TResult> SelectTryGetIterator<T, TResult>(IEnumerable<T> enumerable, FuncTryGet<T, TResult> tryGet)
        {
            return SelectTryGetIterator(enumerable, i => i, tryGet, r => r);
        }

        public static IEnumerable<TResult> SelectTryGetIterator<T, TKey, TResult>(IEnumerable<T> enumerable, Func<T, TKey> keySelector, FuncTryGet<TKey, TResult> tryGet)
        {
            return SelectTryGetIterator(enumerable, keySelector, tryGet, i => i);
        }

        public static IEnumerable<TResult> SelectTryGetIterator<T, TElement, TResult>(IEnumerable<T> enumerable, FuncTryGet<T, TElement> tryGet, Func<TElement, TResult> resultSelector)
        {
            return SelectTryGetIterator(enumerable, i => i, tryGet, resultSelector);
        }

        public static IEnumerable<TResult> SelectTryGetIterator<T, TKey, TElement, TResult>(IEnumerable<T> enumerable, Func<T, TKey> keySelector, FuncTryGet<TKey, TElement> tryGet, Func<TElement, TResult> resultSelector)
        {
            foreach (var item in enumerable)
            {
                if (tryGet(keySelector(item), out TElement element))
                    yield return resultSelector(element);
            }
        }

        #endregion //Private methods
    }
}
