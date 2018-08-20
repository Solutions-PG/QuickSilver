using System;
using System.Collections.Generic;
using System.Linq;
using SolutionsPG.QuickSilver2.Demo.Core.Validation;

namespace SolutionsPG.QuickSilver2.Demo.Core
{
    public struct Validation<T>
    {
        internal IEnumerable<Error> Errors { get; }
        internal T Value { get; }

        public bool IsValid { get; }

        public static Validation<T> Fail(IEnumerable<Error> errors) => new Validation<T>(errors);

        public static Validation<T> Fail(params Error[] errors) => new Validation<T>(errors.AsEnumerable());

        private Validation(IEnumerable<Error> errors)
        {
            this.IsValid = false;
            this.Errors = errors;
            this.Value = default(T);
        }

        internal Validation(T right)
        {
            this.IsValid = true;
            this.Value = right;
            this.Errors = Enumerable.Empty<Error>();
        }

        public static implicit operator Validation<T>(Error error) => new Validation<T>(new[] { error });
        public static implicit operator Validation<T>(Invalid left) => new Validation<T>(left.Errors);
        public static implicit operator Validation<T>(T right) => F.Valid(right);

        public TR Match<TR>(Func<IEnumerable<Error>, TR> invalid, Func<T, TR> valid) => this.IsValid ? valid(this.Value) : invalid(this.Errors);

        public IEnumerator<T> AsEnumerable()
        {
            if (this.IsValid)
            {
                yield return this.Value;
            }
        }

        public override string ToString()
            => (this.IsValid)
                ? $"Valid({this.Value})"
                : $"Invalid([{string.Join(", ", this.Errors)}])";

        public override bool Equals(object obj) => obj is Validation<T> validation && this.Equals(validation); // hack

        public bool Equals(Validation<T> other)
        {
            return Equals(this.Errors, other.Errors) && EqualityComparer<T>.Default.Equals(this.Value, other.Value) && this.IsValid == other.IsValid;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (this.Errors != null ? this.Errors.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ EqualityComparer<T>.Default.GetHashCode(this.Value);
                hashCode = (hashCode * 397) ^ this.IsValid.GetHashCode();
                return hashCode;
            }
        }
    }



    namespace Validation
    {
    }
}
