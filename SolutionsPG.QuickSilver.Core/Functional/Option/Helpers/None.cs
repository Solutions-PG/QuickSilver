using System;

namespace SolutionsPG.QuickSilver.Core.Functional.Option.Helpers
{
    internal static class OptionFunc<T>
    {
        public static Func<Option<T>> None { get; } = OptionFunc<T>.NoneImpl;
        public static Option<T> NoneImpl() => F.None();
    }
}
