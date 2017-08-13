using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;
using SolutionsPG.QuickSilver.Core.Delegates;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool TryGetElementAt<T>(this IEnumerable<T> enumerable, int index, out T returnValue)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            index.ThrowIfArgument(index < 0, nameof(index));

            const bool ElementFound = true;
            const bool ElementNotFound = false;

            using (var enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (index-- == 0)
                    {
                        returnValue = enumerator.Current;
                        return ElementFound;
                    }
                }
            }

            returnValue = default(T);
            return ElementNotFound;
        }

        public static FuncTryGet<int, T> TryGetElementAtAsDelegate<T>(this IEnumerable<T> source)
        {
            source.ThrowIfArgumentNull(nameof(source));

            return TryGetElementAtAsFuncTryGet;

            bool TryGetElementAtAsFuncTryGet(int t, out T result)
            {
                return source.TryGetElementAt(t, out result);
            }
        }

        #endregion //Public methods
    }
}
