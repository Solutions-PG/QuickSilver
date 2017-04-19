using System;

namespace SolutionsPG.QuickSilver.Commons.Interfaces.Disposables
{
    public interface IDisposableValue : IDisposable
    {
        object Value { get; }
    }
}
