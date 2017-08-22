using System;
using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region | Public methods |

        /// <summary>
        /// Indiquate if the source <see cref="IEnumerable{T}"/> contains a maximum of 1 element corresponding to the
        /// predicate.
        /// 
        /// Simplyfied version of <see cref="AtMost{T}(IEnumerable{T}, int, Func{T, bool})"/> for a common scenario.
        /// </summary>
        /// <typeparam name="T">Type of the element of the <see cref="IEnumerable{T}"/></typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> to verify</param>
        /// <param name="predicate">Indiquate if an element meet criteria</param>
        /// <returns>True if the source contains at most 1 element corresponding to the predicate. Else, false.</returns>
        public static bool AtMostOne<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            source.ThrowIfArgumentNull(nameof(source));
            predicate.ThrowIfArgumentNull(nameof(predicate));

            return source.AtMostOne_(predicate);
        }

        /// <summary>
        /// Indiquate if the source <see cref="IEnumerable{T}"/> contains a maximum of 1 element.
        /// 
        /// Simplyfied version of <see cref="AtMost{T}(IEnumerable{T}, int)"/> for a common scenario.
        /// </summary>
        /// <typeparam name="T">Type of the element of the <see cref="IEnumerable{T}"/></typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> to verify</param>
        /// <returns>True if the source contains at most 1 element. Else, false.</returns>
        public static bool AtMostOne<T>(this IEnumerable<T> source)
        {
            source.ThrowIfArgumentNull(nameof(source));

            return source.AtMostOne_();
        }

        /// <summary>
        /// Indiquate if the source <see cref="IEnumerable{T}"/> contains a maximum number of element corresponding to
        /// the predicate.
        /// 
        /// Similar to source.Where(predicate).Skip(maximum).Any() == false
        /// </summary>
        /// <typeparam name="T">Type of the element of the <see cref="IEnumerable{T}"/></typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> to verify</param>
        /// <param name="maximumCount">The highest number of element expected to correspond to the predicate</param>
        /// <param name="predicate">Indiquate if an element meet criteria</param>
        /// <returns>True if the source contains at most the number of element expected to correspond to the predicate. Else, false.</returns>
        public static bool AtMost<T>(this IEnumerable<T> source, int maximumCount, Func<T, bool> predicate)
        {
            source.ThrowIfArgumentNull(nameof(source));
            maximumCount.ThrowIfArgument(maximumCount < 1, nameof(maximumCount));
            predicate.ThrowIfArgumentNull(nameof(predicate));

            return source.AtMost_(maximumCount, predicate);
        }

        /// <summary>
        /// Indiquate if the source <see cref="IEnumerable{T}"/> contains a maximum number of element.
        /// 
        /// Similar to source.Skip(maximumCount).Any() == false
        /// </summary>
        /// <typeparam name="T">Type of the element of the <see cref="IEnumerable{T}"/></typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> to verify</param>
        /// <param name="maximumCount">The highest number of element expected</param>
        /// <returns>True if the source contains at most the number of element expected. Else, false.</returns>
        public static bool AtMost<T>(this IEnumerable<T> source, int maximumCount)
        {
            source.ThrowIfArgumentNull(nameof(source));
            maximumCount.ThrowIfArgument(maximumCount < 1, nameof(maximumCount));

            return source.AtMost_(maximumCount);
        }

        #endregion //Public methods

        #region | Private methods |

        private static bool AtMostOne_<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            using (var enumerator = source.GetEnumerator())
            {
                return (!enumerator.MoveNextWhere_(predicate) || !enumerator.MoveNextWhere_(predicate));
            }
        }

        private static bool AtMostOne_<T>(this IEnumerable<T> source)
        {
            using (var enumerator = source.GetEnumerator())
            {
                return (!enumerator.MoveNext() || !enumerator.MoveNext());
            }
        }

        private static bool AtMost_<T>(this IEnumerable<T> enumerable, int maximumCount, Func<T, bool> predicate)
        {
            using (var enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNextWhere_(predicate))
                {
                    if (--maximumCount == 0)
                        return !enumerator.MoveNextWhere_(predicate);
                }
                return true;
            }
        }

        private static bool AtMost_<T>(this IEnumerable<T> source, int maximumCount)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (--maximumCount == 0)
                        return !enumerator.MoveNext();
                }
                return true;
            }
        }

        #endregion //Private methods
    }
}
