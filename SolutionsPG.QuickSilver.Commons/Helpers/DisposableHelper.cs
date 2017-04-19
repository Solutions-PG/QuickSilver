using System;
using SolutionsPG.QuickSilver.Commons.Disposables;

namespace SolutionsPG.QuickSilver.Commons.Helpers
{
    public sealed class DisposableHelper : Disposable
    {
        #region " Variables "
        
        Action _disposeFunc;

        #endregion //Variables

        #region " Constructors "
        
        public DisposableHelper(Action dispose) : base()
        {
            this._disposeFunc = dispose;
        }

        #endregion //Constructors

        #region " Public methods "

        protected override void DisposeImpl()
        {
            var disposeFunc = _disposeFunc;
            if (disposeFunc == null)
                throw new NotImplementedException();
            disposeFunc();
        }

        #endregion //Public methods
    }
}
