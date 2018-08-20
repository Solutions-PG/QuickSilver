using System;

namespace SolutionsPG.QuickSilver2.Demo.Core
{
    public static partial class F
    {
        public static Core.Option<T> Some<T>(T value) => new Option.Some<T>(value); // wrap the given value into a Some
        public static Option.None None => Option.None.Default;  // the None value

        internal static class Option<T>
        {
            internal static Func<Core.Option<T>> NoneFunc { get; } = () => F.None;
            internal static Func<T, Core.Option<T>> SomeFunc { get; } = F.Some<T>;
        }
        internal static Func<T, Core.Option<R>> ComposedSomeFunc<T, R>(Func<T, R> f) => F.Closure.Compose(f, Option<R>.SomeFunc);

        internal static partial class Closure
        {
            public static Func<T, R> Compose<T, TR, R>(Func<T, TR> f, Func<TR, R> g)
            {
                return new ComposeClosure<T, TR, R>(f, g).Composed;
            }

            private struct ComposeClosure<T, TR, R>
            {
                private readonly Func<T, TR> _f;
                private readonly Func<TR, R> _g;

                public ComposeClosure(Func<T, TR> f, Func<TR, R> g)
                {
                    _f = f;
                    _g = g;
                }

                public R Composed(T t) => _g(_f(t));

            }
        }
    }
}
