using System;
using System.Collections.Generic;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core
{
    public static partial class ObjectExtensions
    {
        #region | Public methods |

        public static bool IsNot<T>(this T obj, T otherObj) => obj.Is_(otherObj) == false;

        public static bool IsNot<T>(this T obj, T otherObj, IEqualityComparer<T> comparer)
        {
            comparer.ThrowIfArgumentNull(nameof(comparer));

            return obj.Is_(otherObj, comparer) == false;
        }

        public static bool IsNot<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality)
        {
            compareEquality.ThrowIfArgumentNull(nameof(compareEquality));

            return obj.Is_(otherObj, compareEquality) == false;
        }

        public static bool IsNot<T>(this T obj, Func<T, bool> predicate)
        {
            predicate.ThrowIfArgumentNull(nameof(predicate));

            return obj.Is_(predicate) == false;
        }

        #endregion //Public methods
    }
}
