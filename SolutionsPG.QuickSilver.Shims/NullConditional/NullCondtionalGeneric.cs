using System;

namespace SolutionsPG.QuickSilver.Shims.NullConditional
{
    /// <summary>
    /// Object used to manage the null-conditional operators shims
    /// </summary>
    /// <typeparam name="T">Type of the potential inner object</typeparam>
    public struct NullConditional<T>
    {
        /// <summary>
        /// Represent an unset value for type T
        /// </summary>
        public static NullConditional<T> Null() { return Lazy.Null; }

        /// <summary>
        /// Can convert a T to a NullCondtional{T}
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator NullConditional<T>(T value)
        {
            return (value == null) ? NullConditional<T>.Null() : new NullConditional<T>(value);
        }

        private static class Lazy
        {
            // ReSharper disable MemberHidesStaticFromOuterClass
            public static readonly NullConditional<T> Null = new NullConditional<T>();
            // ReSharper restore MemberHidesStaticFromOuterClass
            static Lazy() { }
        }

        private readonly bool _hasValue;
        private readonly T _value;

        private NullConditional(T value)
        {
            _hasValue = true;
            _value = value;
        }

        /// <summary>
        /// Can set an action when there is a value and another when their is not.
        /// </summary>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="actionIfNull">Action to execute when there is a value</param>
        /// <param name="actionIfNotNull">Action to execute when there is no value</param>
        /// <returns>Value returned by actionIfNull if there is a value. Else, value returned by actionIfNotNull</returns>
        public TResult Match<TResult>(Func<TResult> actionIfNull, Func<T, TResult> actionIfNotNull)
        {
            return (this._hasValue) ? actionIfNotNull(this._value) : actionIfNull();
        }
    }
}
