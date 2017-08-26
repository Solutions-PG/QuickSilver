using System;
using System.Collections.Generic;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core
{
    public static partial class ObjectExtensions
    {
        #region | Public methods |

        public static bool Is<T>(this T obj, T otherObj)
        {
            return obj.Is_(otherObj);
        }

        public static bool Is<T>(this T obj, T otherObj, IEqualityComparer<T> comparer)
        {
            comparer.ThrowIfArgumentNull(nameof(comparer));

            return obj.Is_(otherObj, comparer);
        }

        public static bool Is<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> compareEquality)
        {
            compareEquality.ThrowIfArgumentNull(nameof(compareEquality));

            return obj.Is_(otherObj, compareEquality);
        }

        public static bool Is<T>(this T obj, Func<T, bool> predicate)
        {
            predicate.ThrowIfArgumentNull(nameof(predicate));

            return obj.Is_(predicate);
        }

        #endregion //Public methods

        #region | Private methods |

        private static bool Is_<T>(this T obj, T otherObj) => obj.Is_(otherObj, EqualityComparer<T>.Default);

        private static bool Is_<T>(this T obj, T otherObj, IEqualityComparer<T> comparer)
        {
            (bool referenceEquals, bool canCompare) = CommonComparison(obj, otherObj);
            return referenceEquals || (canCompare && (comparer.GetHashCode(obj) == comparer.GetHashCode(otherObj)) && comparer.Equals(obj, otherObj));
        }

        private static bool Is_<T, TOther>(this T obj, TOther otherObj, Func<T, TOther, bool> equalityCompare)
        {
            (bool referenceEquals, bool canCompare) = CommonComparison(obj, otherObj);
            return referenceEquals || (canCompare && equalityCompare(obj, otherObj));
        }

        private static bool Is_<T>(this T obj, Func<T, bool> predicate) => predicate(obj);

        private static (bool referenceEquals, bool canCompare) CommonComparison<T, TOther>(T obj, TOther otherObj)
        {
            bool referenceEquals = false;
            bool canCompare = (TypeCache<T>.IsValueType || (((referenceEquals = ReferenceEquals(obj, otherObj)) == false) && (obj != null)));
            return (referenceEquals, canCompare);
        }

        #endregion //Private methods
    }
}
