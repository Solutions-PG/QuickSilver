using System;
using SolutionsPG.QuickSilver.Commons.Disposables;

namespace SolutionsPG.QuickSilver.Commons.Helpers
{
    public class DisposableUnmanagedHelper : DisposableUnmanaged
    {
        #region " Variables "

        Action<bool> _disposeFunc;

        #endregion //Variables

        #region " Constructors "
        
        public DisposableUnmanagedHelper(Action<bool> dispose) : base()
        {
            this._disposeFunc = dispose;
        }

        #endregion //Constructors

        #region " Public methods "

        protected override void DisposeImpl(bool disposing)
        {
            var disposeFunc = this._disposeFunc;
            if (disposeFunc == null)
                throw new NotImplementedException();
            disposeFunc(disposing);
        }

        #endregion //Public methods
    }
}
