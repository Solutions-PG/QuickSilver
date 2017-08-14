using System;
using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Delegates;
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
        /// It's a shortcut, use it when the TryGetValue methods of a dictionary is not recognize as a FuncTryGet{TKey, TValue} delegate.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of the dictionary</typeparam>
        /// <typeparam name="TValue">The type of the values of the dictionary</typeparam>
        /// <param name="dictionary">The dictionary used to cast it's TryGetValue function to a delegate</param>
        /// <returns>The dictionary's TryGetValue casted as a delegate</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameter <see cref="dictionary"/> is null</exception>
        public static FuncTryGet<TKey, TValue> TryGetValueAsDelegate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return dictionary.ThrowIfArgumentNull(nameof(dictionary)).TryGetValue;
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
