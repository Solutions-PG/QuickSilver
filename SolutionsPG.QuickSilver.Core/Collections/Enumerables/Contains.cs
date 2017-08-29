using System;
using System.Collections.Generic;
using System.Linq;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region | Public methods |

        public static bool DoesNotContain<T>(this IEnumerable<T> source, T objToVerify)
        {
            source.ThrowIfArgumentNull(nameof(source));

            return source.Contains_(objToVerify) == false;
        }

        public static bool DoesNotContain<T>(this IEnumerable<T> source, T objToVerify, IEqualityComparer<T> comparer)
        {
            source.ThrowIfArgumentNull(nameof(source));
            comparer.ThrowIfArgumentNull(nameof(comparer));

            return source.Contains_(objToVerify, comparer) == false;
        }

        public static bool DoesNotContain<TSource, TObj>(this IEnumerable<TSource> source, TObj objToVerify, Func<TSource, TObj, bool> comparison)
        {
            source.ThrowIfArgumentNull(nameof(source));
            comparison.ThrowIfArgumentNull(nameof(comparison));

            return source.Contains_(objToVerify, comparison) == false;
        }

        public static bool Contains<TSource, TObj>(this IEnumerable<TSource> source, TObj objToVerify, Func<TSource, TObj, bool> comparison)
        {
            source.ThrowIfArgumentNull(nameof(source));
            comparison.ThrowIfArgumentNull(nameof(comparison));

            return source.Contains_(objToVerify, comparison);
        }

        #endregion //Public methods

        #region | Private methods |

        private static bool Contains_<T>(this IEnumerable<T> source, T objToVerify)
        {
            return source.Contains(objToVerify);
        }

        private static bool Contains_<T>(this IEnumerable<T> source, T objToVerify, IEqualityComparer<T> comparer)
        {
            return source.Contains(objToVerify, comparer);
        }

        private static bool Contains_<TSource, TObj>(this IEnumerable<TSource> source, TObj objToVerify, Func<TSource, TObj, bool> areEquivalent)
        {
            bool AreEqual(TSource s) => areEquivalent(s, objToVerify);
            return source.Any(AreEqual);
        }

        #endregion //Private methods
    }
}
