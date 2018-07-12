using System;

namespace SolutionsPG.QuickSilver.Core.Functional.Option.Helpers
{
    internal static partial class OptionClosure
    {
        public static Func<T, Option<R>> Map<T, R>(Func<T, R> mapFunc) => new MapClosure<T, R>(mapFunc).Map;

        private struct MapClosure<T, R>
        {
            private Func<T, R> MapFunc { get; }
            public MapClosure(Func<T, R> mapFunc) => MapFunc = mapFunc;
            public Option<R> Map(T t) => F.Some(MapFunc(t));
        }
    }
}
