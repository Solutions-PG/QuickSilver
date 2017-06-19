using System;

using SolutionsPG.QuickSilver.Core.Disposables;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Helpers
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

        protected override void DisposeImpl() => _disposeFunc.ThrowIfNull(_ => new NotImplementedException()).Invoke();

        #endregion //Public methods
    }
}
