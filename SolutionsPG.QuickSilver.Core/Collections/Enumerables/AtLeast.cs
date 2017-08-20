using System;
using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region | Public methods |

        /// <summary>
        /// Indiquate if the source <see cref="IEnumerable{T}"/> contains a minimum of 2 elements corresponding to the
        /// predicate.
        /// 
        /// Simplyfied version of <see cref="AtLeast{T}(IEnumerable{T}, int, Func{T, bool})"/> for a common scenario.
        /// </summary>
        /// <typeparam name="T">Type of the element of the <see cref="IEnumerable{T}"/></typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> to verify</param>
        /// <param name="predicate">Indiquate if an element meet criteria</param>
        /// <returns>True if the source contains at least 2 elements corresponding to the predicate. Else, false.</returns>
        public static bool AtLeastTwo<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            source.ThrowIfArgumentNull(nameof(source));
            predicate.ThrowIfArgumentNull(nameof(predicate));

            return AtLeastTwo_(source, predicate);
        }

        /// <summary>
        /// Indiquate if the source <see cref="IEnumerable{T}"/> contains a minimum of 2 elements.
        /// 
        /// Simplyfied version of <see cref="AtLeast{T}(IEnumerable{T}, int)"/> for a common scenario.
        /// </summary>
        /// <typeparam name="T">Type of the element of the <see cref="IEnumerable{T}"/></typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> to verify</param>
        /// <returns>True if the source contains at least 2 elements. Else, false.</returns>
        public static bool AtLeastTwo<T>(this IEnumerable<T> source)
        {
            source.ThrowIfArgumentNull(nameof(source));

            return AtLeastTwo_(source);
        }

        /// <summary>
        /// Indiquate if the source <see cref="IEnumerable{T}"/> contains a minimum number of element corresponding to
        /// the predicate.
        /// 
        /// Similar to source.Where(predicate).Skip(minimumCount - 1).Any()
        /// </summary>
        /// <typeparam name="T">Type of the element of the <see cref="IEnumerable{T}"/></typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> to verify</param>
        /// <param name="minimumCount">The smallest number of element expected to correspond to the predicate</param>
        /// <param name="predicate">Indiquate if an element meet criteria</param>
        /// <returns>True if the source contains at least the number of element expected to correspond to the predicate. Else, false.</returns>
        public static bool AtLeast<T>(this IEnumerable<T> source, int minimumCount, Func<T, bool> predicate)
        {
            source.ThrowIfArgumentNull(nameof(source));
            minimumCount.ThrowIfArgument(minimumCount < 1, nameof(minimumCount));
            predicate.ThrowIfArgumentNull(nameof(predicate));

            return AtLeast_(source, minimumCount, predicate);
        }

        /// <summary>
        /// Indiquate if the source <see cref="IEnumerable{T}"/> contains a minimum number of element.
        /// 
        /// Similar to source.Skip(minimumCount - 1).Any()
        /// </summary>
        /// <typeparam name="T">Type of the element of the <see cref="IEnumerable{T}"/></typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> to verify</param>
        /// <param name="minimumCount">The smallest number of element expected</param>
        /// <returns>True if the source contains at least the number of element expected. Else, false.</returns>
        public static bool AtLeast<T>(this IEnumerable<T> source, int minimumCount)
        {
            source.ThrowIfArgumentNull(nameof(source));
            minimumCount.ThrowIfArgument(minimumCount < 1, nameof(minimumCount));

            return AtLeast_(source, minimumCount);
        }

        #endregion //Public methods

        #region | Private methods |
        
        private static bool AtLeastTwo_<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            using (var enumerator = source.GetEnumerator())
            {
                return (enumerator.MoveNextWhere_(predicate) && enumerator.MoveNextWhere_(predicate));
            }
        }

        private static bool AtLeastTwo_<T>(this IEnumerable<T> source)
        {
            using (var enumerator = source.GetEnumerator())
            {
                return (enumerator.MoveNext() && enumerator.MoveNext());
            }
        }
        private static bool AtLeast_<T>(this IEnumerable<T> source, int minimumCount, Func<T, bool> predicate)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNextWhere_(predicate))
                {
                    if (--minimumCount == 0)
                        return true;
                }
                return false;
            }
        }

        private static bool AtLeast_<T>(this IEnumerable<T> source, int minimumCount)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (--minimumCount == 0)
                        return true;
                }
                return false;
            }
        }

        #endregion //Private methods
    }
}
