using System;

using SolutionsPG.QuickSilver.Core.Disposables;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Helpers
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

        protected override void DisposeImpl(T value) => _disposeFunc.ThrowIfNull(_ => new NotImplementedException()).Invoke(value);

        #endregion //Protected methods
    }
}
