using System;

namespace SolutionsPG.QuickSilver.Core.Interfaces.Disposables
{
    public interface IDisposableValue : IDisposable
    {
        object Value { get; }
    }
}
