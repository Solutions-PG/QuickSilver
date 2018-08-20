using System;
using System.Collections.Generic;

namespace SolutionsPG.QuickSilver2.Demo.Core
{
    public struct Option<T> : IEquatable<Option.None>, IEquatable<Option<T>>
    {

        private readonly T _value;
        private readonly bool _isSome;
        private bool IsNone => !_isSome;

        private Option(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            _isSome = true;
            _value = value;
        }

        public static implicit operator Option<T>(Option.None _) => new Option<T>();
        public static implicit operator Option<T>(Option.Some<T> some) => new Option<T>(some.Value);

        public static implicit operator Option<T>(T value) => (value == null) ? F.None : F.Some(value);

        public R Match<R>(Func<R> none, Func<T, R> some) => (_isSome) ? some(_value) : none();

        public IEnumerable<T> AsEnumerable()
        {
            if (_isSome)
            {
                yield return _value;
            }
        }

        public static bool operator ==(Option<T> @this, Option<T> other) => @this.Equals(other);
        public static bool operator !=(Option<T> @this, Option<T> other) => (@this == other) == false;

        public override string ToString() => _isSome ? $"Some({_value})" : "None";

        public override bool Equals(object obj) => (obj is Option<T> option) && this.Equals(option);
        public bool Equals(Option<T> other) => (_isSome == other._isSome) && (this.IsNone || _value.Equals(other._value));
        public bool Equals(Option.None _) => this.IsNone;

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(_value) * 397) ^ _isSome.GetHashCode();
            }
        }
    }
}
