using System;

namespace SolutionsPG.QuickSilver.Core.Composition
{
    public interface IUsing<out TResource> : IComposable<TResource> where TResource : IDisposable
    {
    }

    public interface IUsing<out TSource, out TResource> : IComposable<TSource, TResource> where TResource : IDisposable
    {
    }

    public interface IUsing<out TSource1, out TSource2, out TResource> : IComposable<TSource1, TSource2, TResource> where TResource : IDisposable
    {
    }
}
