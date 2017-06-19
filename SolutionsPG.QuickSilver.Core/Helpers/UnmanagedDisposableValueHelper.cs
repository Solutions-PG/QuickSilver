using System;

using SolutionsPG.QuickSilver.Core.Disposables;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Helpers
{
    public sealed class UnmanagedDisposableValueHelper<T> : UnmanagedDisposableValue<T>
    {
        #region " Variables "

        Action<bool, T> _disposeFunc;

        #endregion //Variables

        #region " Constructors "
        
        public UnmanagedDisposableValueHelper(T value, Action<bool, T> dispose) : base(value)
        {
            _disposeFunc = dispose;
        }

        #endregion //Constructors

        #region " Protected methods "

        protected override void DisposeImpl(bool disposing, T value) => _disposeFunc.ThrowIfNull(_ => new NotImplementedException()).Invoke(disposing, value);

        #endregion //Protected methods
    }
}
