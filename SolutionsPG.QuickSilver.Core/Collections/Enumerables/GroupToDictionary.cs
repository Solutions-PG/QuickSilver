using System;
using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static IReadOnlyDictionary<TKey, IReadOnlyList<T>> GroupToDictionary<T, TKey>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            keySelector.ThrowIfArgumentNull(nameof(keySelector));

            return enumerable.GroupToDictionary_(keySelector, i => i);
        }

        public static IReadOnlyDictionary<TKey, IReadOnlyList<TElement>> GroupToDictionary<T, TKey, TElement>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector, Func<T, TElement> elementSelector)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            keySelector.ThrowIfArgumentNull(nameof(keySelector));
            elementSelector.ThrowIfArgumentNull(nameof(elementSelector));

            return enumerable.GroupToDictionary_(keySelector, elementSelector);
        }

        #endregion //Public methods

        #region " Private methods "

        private static IReadOnlyDictionary<TKey, IReadOnlyList<TElement>> GroupToDictionary_<T, TKey, TElement>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector, Func<T, TElement> elementSelector)
        {
            var elementsByKey = new Dictionary<TKey, List<TElement>>();
            var readOnlyElementsByKey = new Dictionary<TKey, IReadOnlyList<TElement>>();

            foreach (T item in enumerable)
            {
                TKey currentKey = keySelector(item);
                if (!elementsByKey.TryGetValue(currentKey, out var currentList))
                {
                    currentList = new List<TElement>();
                    elementsByKey.Add(currentKey, currentList);
                    readOnlyElementsByKey.Add(currentKey, currentList.AsReadOnly());
                }

                currentList.Add(elementSelector(item));
            }

            return readOnlyElementsByKey.AsReadOnly();
        }

        #endregion //Private methods
    }
}
