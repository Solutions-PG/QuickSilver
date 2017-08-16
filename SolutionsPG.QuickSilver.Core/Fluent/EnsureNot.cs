using System;

using SolutionsPG.QuickSilver.Core.Exceptions;
using SolutionsPG.QuickSilver.Core.System;

namespace SolutionsPG.QuickSilver.Core.Fluent
{
    public static partial class ObjectExtensions
    {
        #region " Public methods "

        public static T EnsureNotNull<T>(this T obj) where T : new() => obj.EnsureNot_(obj == null, () => FastActivator<T>.CreateInstance());
        public static TObj EnsureNotNull<TObj, TRepl>(this TObj obj, Func<TRepl> getReplacement) where TRepl : TObj
        {
            getReplacement.ThrowIfArgumentNull(nameof(getReplacement));

            return obj.EnsureNot_(obj == null, getReplacement);
        }

        public static TObj EnsureNotNull<TObj, TRepl>(this TObj obj, TRepl replacement) where TRepl : TObj => obj.EnsureNot_(obj == null, replacement);

        public static TObj EnsureNot<TObj, TRepl>(this TObj obj, Func<TObj, bool> condition, Func<TRepl> getReplacement) where TRepl : TObj
        {
            condition.ThrowIfArgumentNull(nameof(condition));
            getReplacement.ThrowIfArgumentNull(nameof(getReplacement));

            return obj.EnsureNot_(condition(obj), getReplacement);
        }

        public static TObj EnsureNot<TObj, TRepl>(this TObj obj, Func<TObj, bool> condition, TRepl replacement) where TRepl : TObj
        {
            condition.ThrowIfArgumentNull(nameof(condition));

            return obj.EnsureNot_(condition(obj), replacement);
        }

        public static TObj EnsureNot<TObj, TRepl>(this TObj obj, bool condition, Func<TRepl> getReplacement) where TRepl : TObj
        {
            getReplacement.ThrowIfArgumentNull(nameof(getReplacement));
            
            return obj.EnsureNot_(condition, getReplacement);
        }

        public static TObj EnsureNot<TObj, TRepl>(this TObj obj, bool condition, TRepl replacement)
            where TRepl : TObj => obj.EnsureNot_(condition, replacement);

        #endregion //Public methods

        #region " Private methods "

        private static TObj EnsureNot_<TObj, TRepl>(this TObj obj, bool condition, Func<TRepl> getReplacement)
            where TRepl : TObj => (condition) ? getReplacement() : obj;

        private static TObj EnsureNot_<TObj, TRepl>(this TObj obj, bool condition, TRepl replacement)
            where TRepl : TObj => (condition) ? replacement : obj;

        #endregion //Private methods
    }
}
