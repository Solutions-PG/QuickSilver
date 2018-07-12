using System;

namespace SolutionsPG.QuickSilver.Core.Functional.Option.Helpers
{
    internal static partial class OptionClosure
    {
        public static Func<T, Option<T>> Where<T>(Func<T, bool> predicateFunc) => new PredicateClosure<T>(predicateFunc).Where;

        private struct PredicateClosure<T>
        {
            private Func<T, bool> PredicateFunc { get; }
            public PredicateClosure(Func<T, bool> predicateFunc) => PredicateFunc = predicateFunc;
            public Option<T> Where(T t) => PredicateFunc(t) ? F.Some(t) : OptionFunc<T>.NoneImpl();
        }
    }
}
