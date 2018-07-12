using System;
using SolutionsPG.QuickSilver.Core.Functional.Option.Helpers;

namespace SolutionsPG.QuickSilver.Core.Functional
{
    public static partial class OptionExtensions
    {
        public static Option<R> Map<T, R>(this in Option<T> optT, Func<T, R> f) => optT.Match(OptionFunc<R>.None, OptionClosure.Map(f));
        public static Option<R> Bind<T, R>(this in Option<T> optT, Func<T, Option<R>> f) => optT.Match(OptionFunc<R>.None, f);
        public static Option<T> Where<T>(this in Option<T> optT, Func<T, bool> predicate) => optT.Match(OptionFunc<T>.None, OptionClosure.Where(predicate));
    }
}
