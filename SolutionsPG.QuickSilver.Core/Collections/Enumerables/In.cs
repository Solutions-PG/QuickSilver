using System.Collections.Generic;
using SolutionsPG.QuickSilver.Core.Exceptions;
using System.Linq;

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

        public static bool NotIn<TObj, TItem>(this TObj obj, params TItem[] enumerable) where TObj : TItem
        {
            return obj.In_(enumerable.ThrowIfArgumentNull(nameof(enumerable))) == false;
        }

        public static bool NotIn<TObj, TItem>(this TObj obj, IEnumerable<TItem> enumerable) where TObj : TItem
        {
            return obj.In_(enumerable.ThrowIfArgumentNull(nameof(enumerable))) == false;
        }

        public static bool InAny<TObj, TItem>(this TObj obj, params IEnumerable<TItem>[] enumerable) where TObj : TItem
        {
            return obj.InAny_(enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        public static bool InAny<TObj, TItem>(this TObj obj, IEnumerable<IEnumerable<TItem>> enumerable) where TObj : TItem
        {
            return obj.InAny_(enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        public static bool InAll<TObj, TItem>(this TObj obj, params IEnumerable<TItem>[] enumerable) where TObj : TItem
        {
            return obj.InAll_(enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        public static bool InAll<TObj, TItem>(this TObj obj, IEnumerable<IEnumerable<TItem>> enumerable) where TObj : TItem
        {
            return obj.InAll_(enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        public static bool InNone<TObj, TItem>(this TObj obj, params IEnumerable<TItem>[] enumerable) where TObj : TItem
        {
            return obj.InAny_(enumerable.ThrowIfArgumentNull(nameof(enumerable))) == false;
        }

        public static bool InNone<TObj, TItem>(this TObj obj, IEnumerable<IEnumerable<TItem>> enumerable) where TObj : TItem
        {
            return obj.InAny_(enumerable.ThrowIfArgumentNull(nameof(enumerable))) == false;
        }

        #endregion //Public methods

        #region " Private methods "

        private static bool In_<TObj, TItem>(this TObj obj, IEnumerable<TItem> enumerable) where TObj : TItem
        {
            return enumerable.Contains(obj);
        }

        private static bool InAny_<TObj, TItem>(this TObj obj, IEnumerable<IEnumerable<TItem>> enumerable) where TObj : TItem
        {
            return enumerable.Any(EnumerableContainsObj);

            bool EnumerableContainsObj(IEnumerable<TItem> e) => e?.Contains(obj) ?? false;
        }

        private static bool InAll_<TObj, TItem>(this TObj obj, IEnumerable<IEnumerable<TItem>> enumerable) where TObj : TItem
        {
            return enumerable.All(EnumerableContainsObj);

            bool EnumerableContainsObj(IEnumerable<TItem> e) => e?.Contains(obj) ?? false;
        }

        #endregion //Private methods
    }
}
