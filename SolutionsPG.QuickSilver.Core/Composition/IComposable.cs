using System;

namespace SolutionsPG.QuickSilver.Core.Composition
{
    public interface IComposable
    {
        TDoResult Execute<TDoResult>(Func<TDoResult> action);
    }

    public interface IComposable<out TResult> : IComposable
    {
        TDoResult Execute<TDoResult>(Func<TResult, TDoResult> action);
    }
}
