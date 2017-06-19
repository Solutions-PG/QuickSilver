using System;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Helpers.ValueTypes
{
    public struct DisposableHelper : IDisposable
    {
        #region " Variables "
        private bool _disposedValue;
        private Action _disposeFunc;

        #endregion //Variables

        #region " Constructors "

        public DisposableHelper(Action dispose)
        {
            _disposedValue = false;
            _disposeFunc = dispose;
        }

        private DisposableHelper(DisposableHelper toCopy) => throw new NotSupportedException();

        #endregion //Constructors

        #region " Public methods "

        public void Dispose()
        {
            if (!_disposedValue)
            {
                _disposeFunc.ThrowIfNull(_ => new NotImplementedException()).Invoke();
                _disposedValue = true;
            }
        }

        #endregion //Public methods
    }
}

