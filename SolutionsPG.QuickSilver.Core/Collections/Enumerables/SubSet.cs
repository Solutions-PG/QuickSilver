using System;
using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Exceptions;
using SolutionsPG.QuickSilver.Core.Fluent;

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

            return enumerable
                .TransformIfOrSelf((index > 0), e => e.Skip(index))
                .Take(quantity);
        }

        public static IEnumerable<T> Subset<T>(this IEnumerable<T> enumerable, Func<T, bool> skipWhile, int quantity)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            skipWhile.ThrowIfArgumentNull(nameof(skipWhile));
            quantity.ThrowIfArgument(quantity <= 0, nameof(quantity));

            return enumerable.SkipWhile(skipWhile).Take(quantity);
        }

        public static IEnumerable<T> Subset<T>(this IEnumerable<T> enumerable, int index, Func<T, bool> takeWhile)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            index.ThrowIfArgument(index < 0, nameof(index));
            takeWhile.ThrowIfArgumentNull(nameof(takeWhile));

            return enumerable
                .TransformIfOrSelf((index > 0), e => e.Skip(index))
                .TakeWhile(takeWhile);
        }

        public static IEnumerable<T> Subset<T>(this IEnumerable<T> enumerable, Func<T, bool> skipWhile, Func<T, bool> takeWhile)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            skipWhile.ThrowIfArgumentNull(nameof(skipWhile));
            takeWhile.ThrowIfArgumentNull(nameof(takeWhile));

            return enumerable.SkipWhile(skipWhile).TakeWhile(takeWhile);
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
