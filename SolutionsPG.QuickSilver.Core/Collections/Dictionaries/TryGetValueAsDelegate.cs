using System.Collections.Generic;
using System.Collections.ObjectModel;

using SolutionsPG.QuickSilver.Core.Exceptions;
using SolutionsPG.QuickSilver.Core.Delegates;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class DictionaryExtensions
    {
        #region " Public methods "

        public static FuncTryGet<TKey, TElement> TryGetValueAsDelegate<TKey, TElement>(this IDictionary<TKey, TElement> dictionary)
        {
            return new FuncTryGet<TKey, TElement>(dictionary.ThrowIfArgumentNull(nameof(dictionary)).TryGetValue);
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
