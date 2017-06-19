using System;

using SolutionsPG.QuickSilver.Core.Interfaces.Disposables;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Helpers.ValueTypes
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
                _disposeFunc.ThrowIfNull(_ => new NotImplementedException()).Invoke(this.Value);
                _disposedValue = true;
            }
        }

        #endregion //Public methods
    }
}
