using System;
using SolutionsPG.QuickSilver.Commons.Interfaces.Disposables;

namespace SolutionsPG.QuickSilver.Commons.Helpers.ValueTypes
{
    public struct DisposableValueHelper<T> : IDisposableValue<T>, IDisposableValue, IDisposable
    {
        #region " Variables "

        private bool _disposedValue;
        private Action<T> _disposeFunc;

        #endregion //Variables

        #region " Public properties "

        public T Value { get; }
        object IDisposableValue.Value => this.Value;

        #endregion //Public properties

        #region " Constructors "

        public DisposableValueHelper(T value, Action<T> dispose)
        {
            _disposedValue = false;
            _disposeFunc = dispose;
            this.Value = value;
        }

        public DisposableValueHelper(DisposableValueHelper<T> toCopy) => throw new NotSupportedException();

        #endregion //Constructors

        #region " Public methods "

        public void Dispose()
        {
            if (!_disposedValue)
            {
                var disposeFunc = _disposeFunc;
                if (disposeFunc == null)
                    throw new NotImplementedException();
                disposeFunc(this.Value);

                _disposedValue = true;
            }
        }

        #endregion //Public methods
    }
}
