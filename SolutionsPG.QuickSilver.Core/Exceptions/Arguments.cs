using System;

namespace SolutionsPG.QuickSilver.Core.Exceptions
{
    public static partial class ThrowExtensions
    {
        #region " Public methods "

        public static T ThrowIfArgumentNull<T>(this T obj, string argumentName) where T : class
        {
            argumentName.ThrowIfArgumentNullOrWhiteSpace(nameof(argumentName));
            return obj.ThrowIf_(obj == null, _ => new ArgumentNullException(argumentName));
        }

        public static string ThrowIfArgumentNullOrWhiteSpace(this string obj, string argumentName)
        {
            argumentName.ThrowIf_(string.IsNullOrWhiteSpace(argumentName), _ => new ArgumentNullException(nameof(argumentName)));
            return obj.ThrowIf_(string.IsNullOrWhiteSpace(obj), _ => new ArgumentNullException(argumentName));
        }

        public static T ThrowIfArgumentDefault<T>(this T obj, string argumentName) where T : struct
        {
            return obj.ThrowIfArgument(obj.Equals(default(T)), argumentName, "Object is still in its default state.");
        }

        public static T ThrowIfArgumentEquals<T>(this T obj, T otherObj, string argumentName)
        {
            return obj.ThrowIfArgumentEquals(otherObj, argumentName, "Object is equals to an invalid state.");
        }

        public static T ThrowIfArgumentEquals<T>(this T obj, T otherObj, string argumentName, string reasons)
        {
            if (otherObj == null)
            {
                ((object)obj).ThrowIfArgumentNull(argumentName);
                return obj;
            }

            return obj.ThrowIfArgument(obj != null && obj.Equals(otherObj), argumentName, reasons);
        }

        public static T ThrowIfArgumentNotEquals<T>(this T obj, T otherObj, string argumentName)
        {
            return obj.ThrowIfArgumentNotEquals(otherObj, argumentName, "Object is not equals to an valid state.");
        }

        public static T ThrowIfArgumentNotEquals<T>(this T obj, T otherObj, string argumentName, string reasons)
        {
            bool condition = (obj == null) ? (otherObj != null) : (otherObj == null) || !obj.Equals(otherObj);
            return obj.ThrowIfArgument(condition, argumentName, reasons);
        }

        public static T ThrowIfArgument<T>(this T obj, Func<T, bool> condition, string argumentName)
        {
            condition.ThrowIfArgumentNull(nameof(condition));
            return obj.ThrowIfArgument(condition(obj), argumentName);
        }

        public static T ThrowIfArgument<T>(this T obj, Func<T, bool> condition, string argumentName, string reasons)
        {
            condition.ThrowIfArgumentNull(nameof(condition));
            return obj.ThrowIfArgument(condition(obj), argumentName, reasons);
        }

        public static T ThrowIfArgument<T>(this T obj, bool condition, string argumentName)
        {
            return obj.ThrowIfArgument(condition, argumentName, "A condition was not met by the argument.");
        }

        public static T ThrowIfArgument<T>(this T obj, bool condition, string argumentName, string reasons)
        {
            argumentName.ThrowIfArgumentNullOrWhiteSpace(nameof(argumentName));
            reasons.ThrowIfArgumentNullOrWhiteSpace(nameof(reasons));
            return obj.ThrowIf_(condition, _ => new ArgumentException(reasons, argumentName));
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
