using System;
using System.Collections.Generic;
using SolutionsPG.QuickSilver.Core.Exceptions;
using System.Linq;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public static partial class EnumerableExtensions
    {
        #region | Public methods |

        #region | In |

        public static bool In<T>(this T obj, params T[] enumerable)
        {
            return obj.In_(enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        public static bool In<T>(this T obj, IEqualityComparer<T> comparer, params T[] enumerable)
        {
            return obj.In_(comparer, enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        public static bool In<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, params TItem[] enumerable)
        {
            return obj.In_(comparison, enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        public static bool In<T>(this T obj, IEnumerable<T> enumerable)
        {
            return obj.In_(enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        public static bool In<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<T> enumerable)
        {
            return obj.In_(comparer, enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        public static bool In<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, IEnumerable<TItem> enumerable)
        {
            return obj.In_(comparison, enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        #endregion //In

        #region | NotIn |

        public static bool NotIn<T>(this T obj, params T[] enumerable)
        {
            return obj.In_(enumerable.ThrowIfArgumentNull(nameof(enumerable))) == false;
        }

        public static bool NotIn<T>(this T obj, IEqualityComparer<T> comparer, params T[] enumerable)
        {
            return obj.In_(comparer, enumerable.ThrowIfArgumentNull(nameof(enumerable))) == false;
        }

        public static bool NotIn<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, params TItem[] enumerable)
        {
            return obj.In_(comparison, enumerable.ThrowIfArgumentNull(nameof(enumerable))) == false;
        }

        public static bool NotIn<T>(this T obj, IEnumerable<T> enumerable)
        {
            return obj.In_(enumerable.ThrowIfArgumentNull(nameof(enumerable))) == false;
        }

        public static bool NotIn<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<T> enumerable)
        {
            return obj.In_(comparer, enumerable.ThrowIfArgumentNull(nameof(enumerable))) == false;
        }

        public static bool NotIn<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, IEnumerable<TItem> enumerable)
        {
            return obj.In_(comparison, enumerable.ThrowIfArgumentNull(nameof(enumerable))) == false;
        }

        #endregion //NotIn

        #region | InAny |

        public static bool InAny<T>(this T obj, params IEnumerable<T>[] enumerables)
        {
            return obj.InAny_(enumerables.ThrowIfArgumentNull(nameof(enumerables)));
        }

        public static bool InAny<T>(this T obj, IEqualityComparer<T> comparer, params IEnumerable<T>[] enumerables)
        {
            return obj.InAny_(comparer, enumerables.ThrowIfArgumentNull(nameof(enumerables)));
        }

        public static bool InAny<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, params IEnumerable<TItem>[] enumerables)
        {
            return obj.InAny_(comparison, enumerables.ThrowIfArgumentNull(nameof(enumerables)));
        }

        public static bool InAny<T>(this T obj, IEnumerable<IEnumerable<T>> enumerables)
        {
            return obj.InAny_(enumerables.ThrowIfArgumentNull(nameof(enumerables)));
        }

        public static bool InAny<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<IEnumerable<T>> enumerables)
        {
            return obj.InAny_(comparer, enumerables.ThrowIfArgumentNull(nameof(enumerables)));
        }

        public static bool InAny<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, IEnumerable<IEnumerable<TItem>> enumerables)
        {
            return obj.InAny_(comparison, enumerables.ThrowIfArgumentNull(nameof(enumerables)));
        }

        #endregion //InAny

        #region | InAll |

        public static bool InAll<T>(this T obj, params IEnumerable<T>[] enumerables)
        {
            return obj.InAll_(enumerables.ThrowIfArgumentNull(nameof(enumerables)));
        }

        public static bool InAll<T>(this T obj, IEqualityComparer<T> comparer, params IEnumerable<T>[] enumerables)
        {
            return obj.InAll_(comparer, enumerables.ThrowIfArgumentNull(nameof(enumerables)));
        }

        public static bool InAll<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, params IEnumerable<TItem>[] enumerables)
        {
            return obj.InAll_(comparison, enumerables.ThrowIfArgumentNull(nameof(enumerables)));
        }

        public static bool InAll<T>(this T obj, IEnumerable<IEnumerable<T>> enumerables)
        {
            return obj.InAll_(enumerables.ThrowIfArgumentNull(nameof(enumerables)));
        }

        public static bool InAll<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<IEnumerable<T>> enumerables)
        {
            return obj.InAll_(comparer, enumerables.ThrowIfArgumentNull(nameof(enumerables)));
        }

        public static bool InAll<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, IEnumerable<IEnumerable<TItem>> enumerables)
        {
            return obj.InAll_(comparison, enumerables.ThrowIfArgumentNull(nameof(enumerables)));
        }

        #endregion //InAll

        #region | InNone |

        public static bool InNone<T>(this T obj, params IEnumerable<T>[] enumerables)
        {
            return obj.InAny_(enumerables.ThrowIfArgumentNull(nameof(enumerables))) == false;
        }

        public static bool InNone<T>(this T obj, IEqualityComparer<T> comparer, params IEnumerable<T>[] enumerables)
        {
            return obj.InAny_(comparer, enumerables.ThrowIfArgumentNull(nameof(enumerables))) == false;
        }

        public static bool InNone<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, params IEnumerable<TItem>[] enumerables)
        {
            return obj.InAny_(comparison, enumerables.ThrowIfArgumentNull(nameof(enumerables))) == false;
        }

        public static bool InNone<T>(this T obj, IEnumerable<IEnumerable<T>> enumerables)
        {
            return obj.InAny_(enumerables.ThrowIfArgumentNull(nameof(enumerables))) == false;
        }

        public static bool InNone<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<IEnumerable<T>> enumerables)
        {
            return obj.InAny_(comparer, enumerables.ThrowIfArgumentNull(nameof(enumerables))) == false;
        }

        public static bool InNone<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, IEnumerable<IEnumerable<TItem>> enumerables)
        {
            return obj.InAny_(comparison, enumerables.ThrowIfArgumentNull(nameof(enumerables))) == false;
        }

        #endregion //InNone

        #endregion //Public methods

        #region | Private methods |

        #region | In_ |

        private static bool In_<T>(this T obj, IEnumerable<T> enumerable)
        {
            return enumerable.Contains(obj);
        }

        private static bool In_<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<T> enumerable)
        {
            return enumerable.Contains(obj, comparer);
        }

        private static bool In_<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, IEnumerable<TItem> enumerable)
        {
            return enumerable.Contains(obj, comparison);
        }

        #endregion //In_

        #region | InAny_ |

        private static bool InAny_<T>(this T obj, IEnumerable<IEnumerable<T>> enumerable)
        {
            bool EnumerableContainsObj(IEnumerable<T> e) => obj.In(e);
            return enumerable.Any(EnumerableContainsObj);
        }

        private static bool InAny_<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<IEnumerable<T>> enumerable)
        {
            bool EnumerableContainsObj(IEnumerable<T> e) => obj.In(comparer, e);
            return enumerable.Any(EnumerableContainsObj);
        }

        private static bool InAny_<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, IEnumerable<IEnumerable<TItem>> enumerable)
        {
            bool EnumerableContainsObj(IEnumerable<TItem> e) => obj.In(comparison, e);
            return enumerable.Any(EnumerableContainsObj);
        }

        #endregion //InAny_

        #region | InAll_ |

        private static bool InAll_<T>(this T obj, IEnumerable<IEnumerable<T>> enumerable)
        {
            bool EnumerableContainsObj(IEnumerable<T> e) => obj.In(e);
            return enumerable.All(EnumerableContainsObj);
        }

        private static bool InAll_<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<IEnumerable<T>> enumerable)
        {
            bool EnumerableContainsObj(IEnumerable<T> e) => obj.In(comparer, e);
            return enumerable.All(EnumerableContainsObj);
        }

        private static bool InAll_<TObj, TItem>(this TObj obj, Func<TObj, TItem, bool> comparison, IEnumerable<IEnumerable<TItem>> enumerable)
        {
            bool EnumerableContainsObj(IEnumerable<TItem> e) => obj.In(comparison, e);
            return enumerable.All(EnumerableContainsObj);
        }

        #endregion //InAll_

        #endregion //Private methods
    }
}
