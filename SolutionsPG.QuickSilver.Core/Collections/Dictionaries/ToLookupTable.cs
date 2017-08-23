using System;
using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    /// <summary>
    /// Contains extensions related to dictionaries
    /// </summary>
    public static partial class DictionaryExtensions
    {
        #region | Public methods |

        /// <summary>
        /// Take a dictionary and reverse it, source values become result keys and vice versa, except the result values
        /// (source keys) are contained in an <see cref="IReadOnlyList{TSourceKey}" />
        /// </summary>
        /// <typeparam name="TSourceKey">Type of the keys from the source</typeparam>
        /// <typeparam name="TSourceValue">Type of the values from the source</typeparam>
        /// <param name="dictionary">The dictionary we want to find keys by value</param>
        /// <returns>
        /// A new reversed dictionary, source values are now result keys and vice versa, except the result values
        /// (source keys) are contained in an <see cref="IReadOnlyList{TSourceKey}" />
        /// </returns>
        public static IReadOnlyDictionary<TSourceValue, IReadOnlyList<TSourceKey>> ToLookupTable<TSourceKey, TSourceValue>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));

            return dictionary.GroupToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        }

        /// <summary>
        /// Take a dictionary and reverse it, source values are used to create result keys and source keys are used as
        /// result values, except the result values (source keys) are contained in an
        /// <see cref="IReadOnlyList{TSourceKey}" />
        /// </summary>
        /// <typeparam name="TSourceKey">Type of the keys from the source</typeparam>
        /// <typeparam name="TSourceValue">Type of the values from the source</typeparam>
        /// <typeparam name="TResultKey">Type of the keys in the resulting dictionary</typeparam>
        /// <param name="dictionary">The dictionary we want to find keys by value</param>
        /// <param name="keySelector">Action to transform a source value to a result key</param>
        /// <returns>
        /// A new reversed dictionary, source values have been used to create result keys and source keys have been used
        /// as result values, except the result values (source keys) are contained in an
        /// <see cref="IReadOnlyList{TSourceKey}" />
        /// </returns>
        public static IReadOnlyDictionary<TResultKey, IReadOnlyList<TSourceKey>> ToLookupTable<TSourceKey, TSourceValue, TResultKey>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary, Func<TSourceValue, TResultKey> keySelector)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            keySelector.ThrowIfArgumentNull(nameof(keySelector));

            TResultKey GetResultKey(KeyValuePair<TSourceKey, TSourceValue> kvp) => keySelector(kvp.Value);
            return dictionary.GroupToDictionary(GetResultKey, kvp => kvp.Key);
        }

        /// <summary>
        /// Take a dictionary and reverse it, source values are used as result keys and source keys are used to create
        /// result values, except the result values (transfomed source keys) are contained in an
        /// <see cref="IReadOnlyList{TResultValue}" />
        /// </summary>
        /// <typeparam name="TSourceKey">Type of the keys from the source</typeparam>
        /// <typeparam name="TSourceValue">Type of the values from the source</typeparam>
        /// <typeparam name="TResultValue">Type of the value in the resulting dictionary</typeparam>
        /// <param name="dictionary">The dictionary we want to find keys by value</param>
        /// <param name="valueSelector">Action to transform a source key to a result value</param>
        /// <returns>
        /// A new reversed dictionary, source values have been used to create result keys and source keys have been used
        /// as result values, except the result values (transfomed source keys) are contained in an
        /// <see cref="IReadOnlyList{TResultValue}" />
        /// </returns>
        public static IReadOnlyDictionary<TSourceValue, IReadOnlyList<TResultValue>> ToLookupTable<TSourceKey, TSourceValue, TResultValue>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary, Func<TSourceKey, TResultValue> valueSelector)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            valueSelector.ThrowIfArgumentNull(nameof(valueSelector));

            TResultValue GetResultValue(KeyValuePair<TSourceKey, TSourceValue> kvp) => valueSelector(kvp.Key);
            return dictionary.GroupToDictionary(kvp => kvp.Value, GetResultValue);
        }

        /// <summary>
        /// Take a dictionary and reverse it, source values are used to create result keys and source keys are used to
        /// create result values, except the result values (source keys) are contained in an
        /// <see cref="IReadOnlyList{TResultValue}" />
        /// </summary>
        /// <typeparam name="TSourceKey">Type of the keys from the source</typeparam>
        /// <typeparam name="TSourceValue">Type of the values from the source</typeparam>
        /// <typeparam name="TResultKey">Type of the keys in the resulting dictionary</typeparam>
        /// <typeparam name="TResultValue">Type of the value in the resulting dictionary</typeparam>
        /// <param name="dictionary">The dictionary we want to find keys by value</param>
        /// <param name="keySelector">Action to transform a source value to a result key</param>
        /// <param name="valueSelector">Action to transform a source key to a result value</param>
        /// <returns>
        /// A new reversed dictionary, source values have been used to create result keys and source keys have been used
        /// to create result values, except the esult values (transfomed source keys) are contained in an
        /// <see cref="IReadOnlyList{TResultValue}" />
        /// </returns>
        public static IReadOnlyDictionary<TResultKey, IReadOnlyList<TResultValue>> ToLookupTable<TSourceKey, TSourceValue, TResultKey, TResultValue>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary, Func<TSourceValue, TResultKey> keySelector, Func<TSourceKey, TResultValue> valueSelector)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            keySelector.ThrowIfArgumentNull(nameof(keySelector));
            valueSelector.ThrowIfArgumentNull(nameof(valueSelector));

            TResultKey GetResultKey(KeyValuePair<TSourceKey, TSourceValue> kvp) => keySelector(kvp.Value);
            TResultValue GetResultValue(KeyValuePair<TSourceKey, TSourceValue> kvp) => valueSelector(kvp.Key);
            return dictionary.GroupToDictionary(GetResultKey, GetResultValue);
        }

        /// <summary>
        /// Take a dictionary and reverse it, source values become result keys and vice versa, except the result values
        /// (source keys) are contained in an <see cref="IReadOnlyList{TSourceKey}" />
        /// </summary>
        /// <typeparam name="TSourceKey">Type of the keys from the source</typeparam>
        /// <typeparam name="TSourceValue">Type of the values from the source</typeparam>
        /// <param name="dictionary">The dictionary we want to find keys by value</param>
        /// <returns>
        /// A new reversed dictionary, source values are now result keys and vice versa, except the result values
        /// (source keys) are contained in an <see cref="IReadOnlyList{TSourceKey}" />
        /// </returns>
        public static IReadOnlyDictionary<TSourceValue, IReadOnlyList<TSourceKey>> ToLookupTable<TSourceKey, TSourceValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));

            return dictionary.ToLookupTable_(sv => sv, sk => sk);
        }

        /// <summary>
        /// Take a dictionary and reverse it, source values are used to create result keys and source keys are used as
        /// result values, except the result values (source keys) are contained in an
        /// <see cref="IReadOnlyList{TSourceKey}" />
        /// </summary>
        /// <typeparam name="TSourceKey">Type of the keys from the source</typeparam>
        /// <typeparam name="TSourceValue">Type of the values from the source</typeparam>
        /// <typeparam name="TResultKey">Type of the keys in the resulting dictionary</typeparam>
        /// <param name="dictionary">The dictionary we want to find keys by value</param>
        /// <param name="keySelector">Action to transform a source value to a result key</param>
        /// <returns>
        /// A new reversed dictionary, source values have been used to create result keys and source keys have been used
        /// as result values, except the result values (source keys) are contained in an
        /// <see cref="IReadOnlyList{TSourceKey}" />
        /// </returns>
        public static IReadOnlyDictionary<TResultKey, IReadOnlyList<TSourceKey>> ToLookupTable<TSourceKey, TSourceValue, TResultKey>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceValue, TResultKey> keySelector)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            keySelector.ThrowIfArgumentNull(nameof(keySelector));

            return dictionary.ToLookupTable_(keySelector, sk => sk);
        }

        /// <summary>
        /// Take a dictionary and reverse it, source values are used as result keys and source keys are used to create
        /// result values, except the result values (transfomed source keys) are contained in an
        /// <see cref="IReadOnlyList{TResultValue}" />
        /// </summary>
        /// <typeparam name="TSourceKey">Type of the keys from the source</typeparam>
        /// <typeparam name="TSourceValue">Type of the values from the source</typeparam>
        /// <typeparam name="TResultValue">Type of the value in the resulting dictionary</typeparam>
        /// <param name="dictionary">The dictionary we want to find keys by value</param>
        /// <param name="valueSelector">Action to transform a source key to a result value</param>
        /// <returns>
        /// A new reversed dictionary, source values have been used to create result keys and source keys have been used
        /// as result values, except the result values (transfomed source keys) are contained in an
        /// <see cref="IReadOnlyList{TResultValue}" />
        /// </returns>
        public static IReadOnlyDictionary<TSourceValue, IReadOnlyList<TResultValue>> ToLookupTable<TSourceKey, TSourceValue, TResultValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceKey, TResultValue> valueSelector)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            valueSelector.ThrowIfArgumentNull(nameof(valueSelector));

            return dictionary.ToLookupTable_(sv => sv, valueSelector);
        }

        /// <summary>
        /// Take a dictionary and reverse it, source values are used to create result keys and source keys are used to
        /// create result values, except the result values (source keys) are contained in an
        /// <see cref="IReadOnlyList{TResultValue}" />
        /// </summary>
        /// <typeparam name="TSourceKey">Type of the keys from the source</typeparam>
        /// <typeparam name="TSourceValue">Type of the values from the source</typeparam>
        /// <typeparam name="TResultKey">Type of the keys in the resulting dictionary</typeparam>
        /// <typeparam name="TResultValue">Type of the value in the resulting dictionary</typeparam>
        /// <param name="dictionary">The dictionary we want to find keys by value</param>
        /// <param name="keySelector">Action to transform a source value to a result key</param>
        /// <param name="valueSelector">Action to transform a source key to a result value</param>
        /// <returns>
        /// A new reversed dictionary, source values have been used to create result keys and source keys have been used
        /// to create result values, except the esult values (transfomed source keys) are contained in an
        /// <see cref="IReadOnlyList{TResultValue}" />
        /// </returns>
        public static IReadOnlyDictionary<TResultKey, IReadOnlyList<TResultValue>> ToLookupTable<TSourceKey, TSourceValue, TResultKey, TResultValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceValue, TResultKey> keySelector, Func<TSourceKey, TResultValue> valueSelector)
        {
            dictionary.ThrowIfArgumentNull(nameof(dictionary));
            keySelector.ThrowIfArgumentNull(nameof(keySelector));
            valueSelector.ThrowIfArgumentNull(nameof(valueSelector));

            return dictionary.ToLookupTable_(keySelector, valueSelector);
        }

        #endregion //Public methods

        #region | Private methods |

        private static IReadOnlyDictionary<TResultKey, IReadOnlyList<TResultValue>> ToLookupTable_<TSourceKey, TSourceValue, TResultKey, TResultValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceValue, TResultKey> keySelector, Func<TSourceKey, TResultValue> valueSelector)
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
