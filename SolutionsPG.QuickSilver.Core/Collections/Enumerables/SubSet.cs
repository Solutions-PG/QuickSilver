using System;
using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static IEnumerable<T> Subset<T>(this IEnumerable<T> enumerable, int index, int quantity)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            index.ThrowIfArgument(index < 0, nameof(index));
            quantity.ThrowIfArgument(quantity <= 0, nameof(quantity));

            return Iterator();

            IEnumerable<T> Iterator()
            {
                using (var enumerator = enumerable.GetEnumerator())
                {
                    while (index > 0 && enumerator.MoveNext()) { --index; }

                    if (index == 0)
                    {
                        while (quantity > 0 && enumerator.MoveNext())
                        {
                            --quantity;
                            yield return enumerator.Current;
                        }
                    }
                }
            }
        }

        public static IEnumerable<T> Subset<T>(this IEnumerable<T> enumerable, Func<T, bool> skipWhile, int quantity)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            skipWhile.ThrowIfArgumentNull(nameof(skipWhile));
            quantity.ThrowIfArgument(quantity <= 0, nameof(quantity));

            return Iterator();

            IEnumerable<T> Iterator()
            {
                using (var enumerator = enumerable.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        bool canTake = true;

                        while (skipWhile(enumerator.Current))
                        {
                            if (enumerator.MoveNext() == false)
                            {
                                canTake = false;
                                break;
                            }
                        }

                        if (canTake && quantity > 0)
                        {
                            do
                            {
                                --quantity;
                                yield return enumerator.Current;
                            } while (quantity > 0 && enumerator.MoveNext());
                        }
                    }
                }
            }
        }

        public static IEnumerable<T> Subset<T>(this IEnumerable<T> enumerable, int index, Func<T, bool> takeWhile)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            index.ThrowIfArgument(index < 0, nameof(index));
            takeWhile.ThrowIfArgumentNull(nameof(takeWhile));

            return Iterator();

            IEnumerable<T> Iterator()
            {
                using (var enumerator = enumerable.GetEnumerator())
                {
                    while (index > 0 && enumerator.MoveNext()) { --index; }

                    if (index == 0)
                    {
                        T currentItem;
                        while (enumerator.MoveNext() && takeWhile(currentItem = enumerator.Current))
                        {
                            yield return currentItem;
                        }
                    }
                }
            }
        }

        public static IEnumerable<T> Subset<T>(this IEnumerable<T> enumerable, Func<T, bool> skipWhile, Func<T, bool> takeWhile)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            skipWhile.ThrowIfArgumentNull(nameof(skipWhile));
            takeWhile.ThrowIfArgumentNull(nameof(takeWhile));

            return Iterator();

            IEnumerable<T> Iterator()
            {
                using (var enumerator = enumerable.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        bool canTake = true;
                        T currentItem = enumerator.Current;

                        while (skipWhile(currentItem))
                        {
                            if (enumerator.MoveNext() == false)
                            {
                                canTake = false;
                                break;
                            }

                            currentItem = enumerator.Current;
                        }
                        
                        if (canTake && takeWhile(currentItem))
                        {
                            do
                            {
                                yield return currentItem;
                            } while (enumerator.MoveNext() && takeWhile(currentItem = enumerator.Current));
                        }
                    }
                }
            }
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
