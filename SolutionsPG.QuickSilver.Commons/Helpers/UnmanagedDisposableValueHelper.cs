using System;
using SolutionsPG.QuickSilver.Commons.Disposables;

namespace SolutionsPG.QuickSilver.Commons.Helpers
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

        protected override void DisposeImpl(bool disposing, T value)
        {
            var disposeFunc = _disposeFunc;
            if (disposeFunc == null)
                throw new NotImplementedException();
            disposeFunc(disposing, value);
        }

        #endregion //Protected methods
    }
}
