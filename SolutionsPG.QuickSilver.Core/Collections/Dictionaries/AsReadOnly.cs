using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    /// <summary>
    /// Contains extensions related to dictionaries
    /// </summary>
    public static partial class DictionaryExtensions
    {
        #region " Public methods "

        /// <summary>
        /// Wrap a non-null IDictionary{TKey, TElement} in a ReadOnlyDictionary{TKey, TElement}
        /// </summary>
        /// <typeparam name="TKey">Type of the keys of the dictionary</typeparam>
        /// <typeparam name="TValue">Type of the values of the dictionary</typeparam>
        /// <param name="dictionary">The dictionary to be wrapped in a ReadOnlyDictionary{TKey, TElement}</param>
        /// <returns>A ReadOnlyDictionary{TKey, TElement} wrapping the received dictionary</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameter <see cref="dictionary"/> is null</exception>
        public static IReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new ReadOnlyDictionary<TKey, TValue>(dictionary.ThrowIfArgumentNull(nameof(dictionary)));
        }

        #endregion //Public methods
    }
}
