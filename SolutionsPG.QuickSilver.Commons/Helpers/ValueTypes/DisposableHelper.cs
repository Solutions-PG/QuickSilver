using System;

namespace SolutionsPG.QuickSilver.Commons.Helpers.ValueTypes
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
                var disposeFunc = _disposeFunc;
                if (disposeFunc == null)
                    throw new NotImplementedException();
                disposeFunc();

                _disposedValue = true;
            }
        }

        #endregion //Public methods
    }
}

