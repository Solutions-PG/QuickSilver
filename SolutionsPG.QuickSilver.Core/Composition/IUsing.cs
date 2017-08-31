using System;

namespace SolutionsPG.QuickSilver.Core.Composition
{
    public interface IUsing<out TResource> : IComposable<TResource> where TResource : IDisposable
    {

    }
}
