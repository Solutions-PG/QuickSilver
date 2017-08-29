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

        public static bool In<T>(this T obj, params T[] others)
        {
            return obj.In_(others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool In<T>(this T obj, IEnumerable<T> others)
        {
            return obj.In_(others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool In<T>(this T obj, IEqualityComparer<T> comparer, params T[] others)
        {
            return obj.In_(comparer, others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool In<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<T> others)
        {
            return obj.In_(comparer, others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool In<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, params TOther[] others)
        {
            return obj.In_(areEquivalent, others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool In<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, IEnumerable<TOther> others)
        {
            return obj.In_(areEquivalent, others.ThrowIfArgumentNull(nameof(others)));
        }

        #endregion //In

        #region | NotIn |

        public static bool NotIn<T>(this T obj, params T[] others)
        {
            return obj.In_(others.ThrowIfArgumentNull(nameof(others))) == false;
        }

        public static bool NotIn<T>(this T obj, IEnumerable<T> others)
        {
            return obj.In_(others.ThrowIfArgumentNull(nameof(others))) == false;
        }

        public static bool NotIn<T>(this T obj, IEqualityComparer<T> comparer, params T[] others)
        {
            return obj.In_(comparer, others.ThrowIfArgumentNull(nameof(others))) == false;
        }

        public static bool NotIn<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<T> others)
        {
            return obj.In_(comparer, others.ThrowIfArgumentNull(nameof(others))) == false;
        }

        public static bool NotIn<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, params TOther[] others)
        {
            return obj.In_(areEquivalent, others.ThrowIfArgumentNull(nameof(others))) == false;
        }

        public static bool NotIn<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, IEnumerable<TOther> others)
        {
            return obj.In_(areEquivalent, others.ThrowIfArgumentNull(nameof(others))) == false;
        }

        #endregion //NotIn

        #region | InAny |

        public static bool InAny<T>(this T obj, params IEnumerable<T>[] others)
        {
            return obj.InAny_(others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool InAny<T>(this T obj, IEnumerable<IEnumerable<T>> others)
        {
            return obj.InAny_(others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool InAny<T>(this T obj, IEqualityComparer<T> comparer, params IEnumerable<T>[] others)
        {
            return obj.InAny_(comparer, others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool InAny<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<IEnumerable<T>> others)
        {
            return obj.InAny_(comparer, others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool InAny<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, params IEnumerable<TOther>[] others)
        {
            return obj.InAny_(areEquivalent, others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool InAny<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, IEnumerable<IEnumerable<TOther>> others)
        {
            return obj.InAny_(areEquivalent, others.ThrowIfArgumentNull(nameof(others)));
        }

        #endregion //InAny

        #region | InAll |

        public static bool InAll<T>(this T obj, params IEnumerable<T>[] others)
        {
            return obj.InAll_(others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool InAll<T>(this T obj, IEnumerable<IEnumerable<T>> others)
        {
            return obj.InAll_(others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool InAll<T>(this T obj, IEqualityComparer<T> comparer, params IEnumerable<T>[] others)
        {
            return obj.InAll_(comparer, others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool InAll<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<IEnumerable<T>> others)
        {
            return obj.InAll_(comparer, others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool InAll<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, params IEnumerable<TOther>[] others)
        {
            return obj.InAll_(areEquivalent, others.ThrowIfArgumentNull(nameof(others)));
        }

        public static bool InAll<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, IEnumerable<IEnumerable<TOther>> others)
        {
            return obj.InAll_(areEquivalent, others.ThrowIfArgumentNull(nameof(others)));
        }

        #endregion //InAll

        #region | InNone |

        public static bool InNone<T>(this T obj, params IEnumerable<T>[] others)
        {
            return obj.InAny_(others.ThrowIfArgumentNull(nameof(others))) == false;
        }

        public static bool InNone<T>(this T obj, IEnumerable<IEnumerable<T>> others)
        {
            return obj.InAny_(others.ThrowIfArgumentNull(nameof(others))) == false;
        }

        public static bool InNone<T>(this T obj, IEqualityComparer<T> comparer, params IEnumerable<T>[] others)
        {
            return obj.InAny_(comparer, others.ThrowIfArgumentNull(nameof(others))) == false;
        }

        public static bool InNone<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<IEnumerable<T>> others)
        {
            return obj.InAny_(comparer, others.ThrowIfArgumentNull(nameof(others))) == false;
        }

        public static bool InNone<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, params IEnumerable<TOther>[] others)
        {
            return obj.InAny_(areEquivalent, others.ThrowIfArgumentNull(nameof(others))) == false;
        }

        public static bool InNone<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, IEnumerable<IEnumerable<TOther>> others)
        {
            return obj.InAny_(areEquivalent, others.ThrowIfArgumentNull(nameof(others))) == false;
        }

        #endregion //InNone

        #endregion //Public methods

        #region | Private methods |

        #region | In_ |

        private static bool In_<T>(this T obj, IEnumerable<T> others)
        {
            return others.Contains(obj);
        }

        private static bool In_<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<T> others)
        {
            return others.Contains(obj, comparer);
        }

        private static bool In_<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, IEnumerable<TOther> others)
        {
            bool AreEquivalent(TOther s, T o) => areEquivalent(o, s);
            return others.Contains_(obj, AreEquivalent);
        }

        #endregion //In_

        #region | InAny_ |

        private static bool InAny_<T>(this T obj, IEnumerable<IEnumerable<T>> others)
        {
            bool ObjInNested(IEnumerable<T> e) => obj.In(e);
            return others.Any(ObjInNested);
        }

        private static bool InAny_<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<IEnumerable<T>> others)
        {
            bool ObjInNested(IEnumerable<T> e) => obj.In(comparer, e);
            return others.Any(ObjInNested);
        }

        private static bool InAny_<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, IEnumerable<IEnumerable<TOther>> others)
        {
            bool ObjInNested(IEnumerable<TOther> e) => obj.In(areEquivalent, e);
            return others.Any(ObjInNested);
        }

        #endregion //InAny_

        #region | InAll_ |

        private static bool InAll_<T>(this T obj, IEnumerable<IEnumerable<T>> others)
        {
            bool ObjInNested(IEnumerable<T> e) => obj.In(e);
            return others.All(ObjInNested);
        }

        private static bool InAll_<T>(this T obj, IEqualityComparer<T> comparer, IEnumerable<IEnumerable<T>> others)
        {
            bool ObjInNested(IEnumerable<T> e) => obj.In(comparer, e);
            return others.All(ObjInNested);
        }

        private static bool InAll_<T, TOther>(this T obj, Func<T, TOther, bool> areEquivalent, IEnumerable<IEnumerable<TOther>> others)
        {
            bool ObjInNested(IEnumerable<TOther> e) => obj.In(areEquivalent, e);
            return others.All(ObjInNested);
        }

        #endregion //InAll_

        #endregion //Private methods
    }
}
