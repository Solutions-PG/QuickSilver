using System;

namespace SolutionsPG.QuickSilver2.Demo.Core
{
    public static class OptionExtensions
    {
        public static Option<R> Map<T, R>(this in Option<T> optT, Func<T, R> f) => optT.Match(F.Option<R>.NoneFunc, F.ComposedSomeFunc(f));
        public static Option<R> Bind<T, R>(this in Option<T> optT, Func<T, Option<R>> f) => optT.Match(F.Option<R>.NoneFunc, f);
        public static Option<T> Where<T>(this in Option<T> optT, Func<T, bool> predicate) => optT.Match(Closure.Return(optT), Closure.Qqc(predicate, F.None, optT));

        internal static partial class Closure
        {
            public static Func<T> Return<T>(T t)
            {
                return new ReturnClosure<T>(t).Return;
            }

            public static Func<T, R> Qqc<T, R>(Func<T, bool> condition, R r1, R r2)
            {
                return new QqcClosure<T, R>(condition, r1, r2).Return;
            }

            private struct ReturnClosure<T>
            {
                private readonly T _t;
                public ReturnClosure(T t) => _t = t;
                public T Return() => _t;
            }

            private struct QqcClosure<T, R>
            {
                private readonly Func<T, bool> _condition;
                private readonly R _r1;
                private readonly R _r2;

                public QqcClosure(Func<T, bool> condition, R r1, R r2)
                {
                    _condition = condition;
                    _r1 = r1;
                    _r2 = r2;
                }

                public R Return(T t) => _condition(t) ? _r1 : _r2;

            }
        }
    }
}