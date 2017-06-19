using System.Collections.Generic;
using System.Collections.ObjectModel;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class DictionaryExtensions
    {
        #region " Public methods "

        public static IReadOnlyDictionary<TKey, TElement> AsReadOnly<TKey, TElement>(this IDictionary<TKey, TElement> dictionary)
        {
            return new ReadOnlyDictionary<TKey, TElement>(dictionary.ThrowIfArgumentNull(nameof(dictionary)));
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
