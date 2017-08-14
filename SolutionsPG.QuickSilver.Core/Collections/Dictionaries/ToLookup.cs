using System.Collections.Generic;
using System.Collections.ObjectModel;

using SolutionsPG.QuickSilver.Core.Exceptions;
using System;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    /// <summary>
    /// Contains extensions related to dictionaries
    /// </summary>
    public static partial class DictionaryExtensions
    {
        #region " Public methods "

        public static IReadOnlyDictionary<TValue, IReadOnlyList<TKey>> ToLookup<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));

            return dictionary.GroupToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        }

        public static IReadOnlyDictionary<TResultKey, IReadOnlyList<TSourceKey>> ToLookup<TSourceKey, TSourceValue, TResultKey>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary, Func<TSourceValue, TResultKey> keySelector)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            keySelector.ThrowIfArgumentNull(nameof(keySelector));

            return dictionary.GroupToDictionary(kvp => keySelector(kvp.Value), kvp => kvp.Key);
        }

        public static IReadOnlyDictionary<TSourceValue, IReadOnlyList<TResultValue>> ToLookup<TSourceKey, TSourceValue, TResultValue>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary, Func<TSourceKey, TResultValue> valueSelector)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            valueSelector.ThrowIfArgumentNull(nameof(valueSelector));

            return dictionary.GroupToDictionary(kvp => kvp.Value, kvp => valueSelector(kvp.Key));
        }

        public static IReadOnlyDictionary<TResultKey, IReadOnlyList<TResultValue>> ToLookup<TSourceKey, TSourceValue, TResultKey, TResultValue>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary, Func<TSourceValue, TResultKey> keySelector, Func<TSourceKey, TResultValue> valueSelector)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            keySelector.ThrowIfArgumentNull(nameof(keySelector));
            valueSelector.ThrowIfArgumentNull(nameof(valueSelector));

            return dictionary.GroupToDictionary(kvp => keySelector(kvp.Value), kvp => valueSelector(kvp.Key));
        }

        public static IReadOnlyDictionary<TSourceValue, IReadOnlyList<TSourceKey>> ToLookup<TSourceKey, TSourceValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));

            return dictionary.ToLookup_(sv => sv, sk => sk);
        }

        public static IReadOnlyDictionary<TResultKey, IReadOnlyList<TSourceKey>> ToLookup<TSourceKey, TSourceValue, TResultKey>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceValue, TResultKey> keySelector)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            keySelector.ThrowIfArgumentNull(nameof(keySelector));

            return dictionary.ToLookup_(keySelector, sk => sk);
        }

        public static IReadOnlyDictionary<TSourceValue, IReadOnlyList<TResultValue>> ToLookup<TSourceKey, TSourceValue, TResultValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceKey, TResultValue> valueSelector)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            valueSelector.ThrowIfArgumentNull(nameof(valueSelector));

            return dictionary.ToLookup_(sv => sv, valueSelector);
        }

        public static IReadOnlyDictionary<TResultKey, IReadOnlyList<TResultValue>> ToLookup<TSourceKey, TSourceValue, TResultKey, TResultValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceValue, TResultKey> keySelector, Func<TSourceKey, TResultValue> valueSelector)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            keySelector.ThrowIfArgumentNull(nameof(keySelector));
            valueSelector.ThrowIfArgumentNull(nameof(valueSelector));

            return dictionary.ToLookup_(keySelector, valueSelector);
        }

        #endregion //Public methods

        #region " Private methods "

        private static IReadOnlyDictionary<TResultKey, IReadOnlyList<TResultValue>> ToLookup_<TSourceKey, TSourceValue, TResultKey, TResultValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceValue, TResultKey> keySelector, Func<TSourceKey, TResultValue> valueSelector)
        {
            var elementsByKey = new Dictionary<TResultKey, List<TResultValue>>();
            var readOnlyElementsByKey = new Dictionary<TResultKey, IReadOnlyList<TResultValue>>();

            foreach (var kvp in dictionary)
            {
                var sourceKey = kvp.Key;
                var sourceList = kvp.Value;
                if (sourceList != null)
                {
                    foreach (TSourceValue item in sourceList)
                    {
                        TResultKey currentKey = keySelector(item);
                        if (!elementsByKey.TryGetValue(currentKey, out var currentList))
                        {
                            currentList = new List<TResultValue>();
                            elementsByKey.Add(currentKey, currentList);
                            readOnlyElementsByKey.Add(currentKey, currentList.AsReadOnly());
                        }

                        currentList.Add(valueSelector(sourceKey));
                    }
                }
            }

            return readOnlyElementsByKey.AsReadOnly();
        }

        #endregion //Private methods
    }
}
