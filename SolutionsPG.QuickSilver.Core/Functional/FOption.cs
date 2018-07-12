using System;

namespace SolutionsPG.QuickSilver.Core.Functional
{
    public static partial class F
    {
        public static Option.None None() => Option.None.Default;
        public static Option.Some<T> Some<T>(T value) => new Option.Some<T>(value);
    }
}
