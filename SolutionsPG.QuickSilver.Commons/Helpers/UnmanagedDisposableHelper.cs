using System;
using SolutionsPG.QuickSilver.Commons.Disposables;

namespace SolutionsPG.QuickSilver.Commons.Helpers
{
    public sealed class UnmanagedDisposableHelper : UnmanagedDisposable
    {
        #region " Variables "

        Action<bool> _disposeFunc;

        #endregion //Variables

        #region " Constructors "
        
        public UnmanagedDisposableHelper(Action<bool> dispose) : base()
        {
            _disposeFunc = dispose;
        }

        #endregion //Constructors

        #region " Public methods "

        protected override void DisposeImpl(bool disposing)
        {
            var disposeFunc = _disposeFunc;
            if (disposeFunc == null)
                throw new NotImplementedException();
            disposeFunc(disposing);
        }

        #endregion //Public methods
    }
}
