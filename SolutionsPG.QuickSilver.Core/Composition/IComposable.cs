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

    public interface IComposable<out TSource, out TResult> : IComposable<TResult>
    {
        TDoResult Execute<TDoResult>(Func<TSource, TDoResult> action);
        TDoResult Execute<TDoResult>(Func<TSource, TResult, TDoResult> action);
    }

    public interface IComposable<out TSource1, out TSource2, out TResult> : IComposable<TSource2, TResult>
    {
        TDoResult Execute<TDoResult>(Func<TSource1, TDoResult> action);
        TDoResult Execute<TDoResult>(Func<TSource1, TResult, TDoResult> action);
        TDoResult Execute<TDoResult>(Func<TSource1, TSource2, TDoResult> action);
        TDoResult Execute<TDoResult>(Func<TSource1, TSource2, TResult, TDoResult> action);
    }
}
