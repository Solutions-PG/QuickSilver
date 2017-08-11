using System;

namespace SolutionsPG.QuickSilver.Core.Exceptions
{
    public static partial class ThrowExtensions
    {
        #region " Public methods "

        public static T ThrowIfArgumentNull<T>(this T obj, string argumentName) where T : class
        {
            argumentName.ThrowIfArgumentNullOrWhiteSpace_(nameof(argumentName));

            return obj.ThrowIfArgumentNull_(argumentName);
        }

        public static string ThrowIfArgumentNullOrWhiteSpace(this string obj, string argumentName)
        {
            argumentName.ThrowIfArgumentNullOrWhiteSpace_(nameof(argumentName));

            return obj.ThrowIfArgumentNullOrWhiteSpace_(argumentName);
        }

        public static T ThrowIfArgumentDefault<T>(this T obj, string argumentName) where T : struct
        {
            argumentName.ThrowIfArgumentNullOrWhiteSpace_(nameof(argumentName));

            return obj.ThrowIfArgumentDefault_(argumentName);
        }

        public static T ThrowIfArgumentEquals<T>(this T obj, T otherObj, string argumentName)
        {
            argumentName.ThrowIfArgumentNullOrWhiteSpace_(nameof(argumentName));

            return obj.ThrowIfArgumentEquals_(otherObj, argumentName);
        }

        public static T ThrowIfArgumentEquals<T>(this T obj, T otherObj, string argumentName, string reasons)
        {
            argumentName.ThrowIfArgumentNullOrWhiteSpace_(nameof(argumentName));
            reasons.ThrowIfArgumentNullOrWhiteSpace_(nameof(reasons));
            
            return obj.ThrowIfArgumentEquals_(otherObj, argumentName, reasons);
        }

        public static T ThrowIfArgumentNotEquals<T>(this T obj, T otherObj, string argumentName)
        {
            argumentName.ThrowIfArgumentNullOrWhiteSpace_(nameof(argumentName));

            return obj.ThrowIfArgumentNotEquals_(otherObj, argumentName);
        }

        public static T ThrowIfArgumentNotEquals<T>(this T obj, T otherObj, string argumentName, string reasons)
        {
            argumentName.ThrowIfArgumentNullOrWhiteSpace_(nameof(argumentName));
            reasons.ThrowIfArgumentNullOrWhiteSpace_(nameof(reasons));

            return obj.ThrowIfArgumentNotEquals_(otherObj, argumentName, reasons);
        }

        public static T ThrowIfArgument<T>(this T obj, Func<T, bool> condition, string argumentName)
        {
            condition.ThrowIfArgumentNull(nameof(condition));
            argumentName.ThrowIfArgumentNullOrWhiteSpace_(nameof(argumentName));

            return obj.ThrowIfArgument_(condition(obj), argumentName);
        }

        public static T ThrowIfArgument<T>(this T obj, Func<T, bool> condition, string argumentName, string reasons)
        {
            condition.ThrowIfArgumentNull(nameof(condition));
            argumentName.ThrowIfArgumentNullOrWhiteSpace_(nameof(argumentName));
            reasons.ThrowIfArgumentNullOrWhiteSpace_(nameof(reasons));

            return obj.ThrowIfArgument_(condition, argumentName, reasons);
        }

        public static T ThrowIfArgument<T>(this T obj, bool condition, string argumentName)
        {
            argumentName.ThrowIfArgumentNullOrWhiteSpace_(nameof(argumentName));

            return obj.ThrowIfArgument_(condition, argumentName);
        }

        public static T ThrowIfArgument<T>(this T obj, bool condition, string argumentName, string reasons)
        {
            argumentName.ThrowIfArgumentNullOrWhiteSpace_(nameof(argumentName));
            reasons.ThrowIfArgumentNullOrWhiteSpace_(nameof(reasons));

            return obj.ThrowIfArgument_(condition, argumentName, reasons);
        }

        #endregion //Public methods

        #region " Private methods "

        private static T ThrowIfArgumentNull_<T>(this T obj, string argumentName) where T : class
        {
            return obj.ThrowIf_(obj == null, _ => new ArgumentNullException(argumentName));
        }

        private static string ThrowIfArgumentNullOrWhiteSpace_(this string obj, string argumentName)
        {
            return obj.ThrowIf_(string.IsNullOrWhiteSpace(obj), _ => new ArgumentNullException(argumentName));
        }

        private static T ThrowIfArgumentDefault_<T>(this T obj, string argumentName) where T : struct
        {
            return obj.ThrowIfArgumentEquals_(default(T), argumentName, "Object is equals to an invalid state.");
        }

        private static T ThrowIfArgumentEquals_<T>(this T obj, T otherObj, string argumentName)
        {
            return obj.ThrowIfArgumentEquals_(otherObj, argumentName, "Object is equals to an invalid state.");
        }

        private static T ThrowIfArgumentEquals_<T>(this T obj, T otherObj, string argumentName, string reasons)
        {
            bool condition = (obj == null) ? (otherObj == null) : (otherObj != null) && obj.Equals(otherObj);
            return obj.ThrowIfArgument_(condition, argumentName, reasons);
        }

        private static T ThrowIfArgumentNotEquals_<T>(this T obj, T otherObj, string argumentName)
        {
            return obj.ThrowIfArgumentNotEquals_(otherObj, argumentName, "Object is not equals to an valid state.");
        }

        private static T ThrowIfArgumentNotEquals_<T>(this T obj, T otherObj, string argumentName, string reasons)
        {
            bool condition = (obj == null) ? (otherObj != null) : (otherObj == null) || !obj.Equals(otherObj);
            return obj.ThrowIfArgument_(condition, argumentName, reasons);
        }

        private static T ThrowIfArgument_<T>(this T obj, Func<T, bool> condition, string argumentName)
        {
            return obj.ThrowIfArgument_(condition(obj), argumentName);
        }

        private static T ThrowIfArgument_<T>(this T obj, Func<T, bool> condition, string argumentName, string reasons)
        {
            return obj.ThrowIfArgument_(condition(obj), argumentName, reasons);
        }

        private static T ThrowIfArgument_<T>(this T obj, bool condition, string argumentName)
        {
            return obj.ThrowIfArgument_(condition, argumentName, "A condition was not met by the argument.");
        }

        private static T ThrowIfArgument_<T>(this T obj, bool condition, string argumentName, string reasons)
        {
            return obj.ThrowIf_(condition, _ => new ArgumentException(reasons, argumentName));
        }

        #endregion //Private methods
    }
}
