using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Delegates;
using SolutionsPG.QuickSilver.Core.Exceptions;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using SolutionsPG.QuickSilver.Core.Fluent;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static bool In<TObj, TItem>(this TObj obj, params TItem[] enumerable) where TObj : TItem
        {
            return obj.In_(enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        public static bool In<TObj, TItem>(this TObj obj, IEnumerable<TItem> enumerable) where TObj : TItem
        {
            return obj.In_(enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        public static bool InAny<TObj, TItem>(this TObj obj, params IEnumerable<TItem>[] enumerable) where TObj : TItem
        {
            return obj.InAny_(enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        public static bool InAny<TObj, TItem>(this TObj obj, IEnumerable<IEnumerable<TItem>> enumerable) where TObj : TItem
        {
            return obj.InAny_(enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        #endregion //Public methods

        #region " Private methods "

        private static bool In_<TObj, TItem>(this TObj obj, IEnumerable<TItem> enumerable) where TObj : TItem
        {
            return enumerable.ThrowIfArgumentNull(nameof(enumerable)).Contains(obj);
        }

        private static bool InAny_<TObj, TItem>(this TObj obj, IEnumerable<IEnumerable<TItem>> enumerable) where TObj : TItem
        {
            return enumerable.ThrowIfArgumentNull(nameof(enumerable)).Any(EnumerableContainsObj);

            bool EnumerableContainsObj(IEnumerable<TItem> e) => e?.Contains(obj) ?? false;
        }

        #endregion //Private methods
    }
}
