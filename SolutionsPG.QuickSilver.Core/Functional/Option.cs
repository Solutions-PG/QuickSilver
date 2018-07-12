using System;
using SolutionsPG.QuickSilver.Core.Functional.Option.Helpers;

namespace SolutionsPG.QuickSilver.Core.Functional
{
    public struct Option<T>
    {
        private bool HasValue { get; }
        private T Value { get; }

        private Option(T value) : this()
        {
            this.HasValue = true;
            this.Value = value;
        }
        
        public static implicit operator Option<T>(Option.None _) => new Option<T>();
        public static implicit operator Option<T>(Option.Some<T> some) => new Option<T>(some.Value);

        public static implicit operator Option<T>(T value) => (value == null) ? OptionFunc<T>.None() : F.Some(value);
        public static explicit operator T(Option<T> option) => option.GetOrDefaut();

        public TResult Match<TResult>(Func<TResult> none, Func<T, TResult> some) => this.HasValue ? some(this.Value) : none();

        public T GetOrDefaut() => (this.HasValue) ? this.Value : default;
    }
}
