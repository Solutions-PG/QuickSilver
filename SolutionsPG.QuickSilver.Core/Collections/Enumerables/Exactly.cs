using System;
using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region | Public methods |

        /// <summary>
        /// Indiquate if the source <see cref="IEnumerable{T}"/> contains exactly 1 element corresponding to the
        /// predicate.
        /// 
        /// Simplyfied version of <see cref="Exactly{T}(IEnumerable{T}, int, Func{T, bool})"/> for a common scenario.
        /// </summary>
        /// <typeparam name="T">Type of the element of the <see cref="IEnumerable{T}"/></typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> to verify</param>
        /// <param name="predicate">Indiquate if an element meet criteria</param>
        /// <returns>True if the source contains exactly 1 element corresponding to the predicate. Else, false.</returns>
        public static bool One<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            source.ThrowIfArgumentNull(nameof(source));
            predicate.ThrowIfArgumentNull(nameof(predicate));

            return source.One_(predicate);
        }

        /// <summary>
        /// Indiquate if the source <see cref="IEnumerable{T}"/> contains exactly 1 element.
        /// 
        /// Simplyfied version of <see cref="Exactly{T}(IEnumerable{T}, int)"/> for a common scenario.
        /// </summary>
        /// <typeparam name="T">Type of the element of the <see cref="IEnumerable{T}"/></typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> to verify</param>
        /// <returns>True if the source contains exactly 1 element. Else, false.</returns>
        public static bool One<T>(this IEnumerable<T> source)
        {
            source.ThrowIfArgumentNull(nameof(source));

            return source.One_();
        }

        /// <summary>
        /// Indiquate if the source <see cref="IEnumerable{T}"/> contains an exact number of element corresponding to
        /// the predicate.
        /// 
        /// Similar to source.Where(predicate).Take(count + 1).Count() == count
        /// </summary>
        /// <typeparam name="T">Type of the element of the <see cref="IEnumerable{T}"/></typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> to verify</param>
        /// <param name="count">The exact number of element expected to correspond to the predicate</param>
        /// <param name="predicate">Indiquate if an element meet criteria</param>
        /// <returns>True if the source contains exactly the number of element expected to correspond to the predicate. Else, false.</returns>
        public static bool Exactly<T>(this IEnumerable<T> source, int count, Func<T, bool> predicate)
        {
            source.ThrowIfArgumentNull(nameof(source));
            count.ThrowIfArgument(count < 1, nameof(count));

            return source.Exactly_(count, predicate);
        }

        /// <summary>
        /// Indiquate if the source <see cref="IEnumerable{T}"/> contains an exact number of element.
        /// 
        /// Similar to source.Take(count + 1).Count() == count
        /// </summary>
        /// <typeparam name="T">Type of the element of the <see cref="IEnumerable{T}"/></typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> to verify</param>
        /// <param name="count">The exact number of element expected</param>
        /// <returns>True if the source contains exactly the number of element expected. Else, false.</returns>
        public static bool Exactly<T>(this IEnumerable<T> source, int count)
        {
            source.ThrowIfArgumentNull(nameof(source));
            count.ThrowIfArgument(count < 1, nameof(count));

            return source.Exactly_(count);
        }

        #endregion //Public methods

        #region | Private methods |

        private static bool One_<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool MoveNextWhere(IEnumerator<T> enumerator) => enumerator.MoveNextWhere_(predicate);
            return source.__One__(MoveNextWhere);
        }

        private static bool One_<T>(this IEnumerable<T> source)
        {
            bool MoveNext(IEnumerator<T> enumerator) => enumerator.MoveNext();
            return source.__One__(MoveNext);
        }

        private static bool __One__<T>(this IEnumerable<T> source, Func<IEnumerator<T>, bool> moveNext)
        {
            using (var enumerator = source.GetEnumerator())
            {
                return (moveNext(enumerator) && !moveNext(enumerator));
            }
        }

        private static bool Exactly_<T>(this IEnumerable<T> source, int count, Func<T, bool> predicate)
        {
            bool MoveNextWhere(IEnumerator<T> enumerator) => enumerator.MoveNextWhere_(predicate);
            return source.__Exactly__(count, MoveNextWhere);
        }

        private static bool Exactly_<T>(this IEnumerable<T> source, int count)
        {
            bool MoveNext(IEnumerator<T> enumerator) => enumerator.MoveNext();
            return source.__Exactly__(count, MoveNext);
        }

        private static bool __Exactly__<T>(this IEnumerable<T> source, int count, Func<IEnumerator<T>, bool> moveNext)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (moveNext(enumerator))
                {
                    if (--count == 0)
                        return !moveNext(enumerator);
                }
                return false;
            }
        }

        #endregion //Private methods
    }
}
