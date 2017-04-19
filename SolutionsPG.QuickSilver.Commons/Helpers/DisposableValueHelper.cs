using System;
using SolutionsPG.QuickSilver.Commons.Disposables;

namespace SolutionsPG.QuickSilver.Commons.Helpers
{
    public sealed class DisposableValueHelper<T> : DisposableValue<T>
    {
        #region " Variables "

        Action<T> _disposeFunc;

        #endregion //Variables

        #region " Constructors "
        
        public DisposableValueHelper(T value, Action<T> dispose) : base(value)
        {
            _disposeFunc = dispose;
        }

        #endregion //Constructors

        #region " Protected methods "

        protected override void DisposeImpl(T value)
        {
            var disposeFunc = _disposeFunc;
            if (disposeFunc == null)
                throw new NotImplementedException();
            disposeFunc(value);
        }

        #endregion //Protected methods
    }
}
