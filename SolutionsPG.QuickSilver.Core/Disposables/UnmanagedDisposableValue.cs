using SolutionsPG.QuickSilver.Core.Helpers;
using System;
using System.Collections.Generic;

namespace SolutionsPG.QuickSilver.Core.Disposables
{

    public abstract class UnmanagedDisposableValue<T> : IDisposable
    {
        #region " Variables "

        IDisposable _disposableHelper;
        T Value { get; }

        #endregion //Variables

        #region " Constructors "

        protected UnmanagedDisposableValue(T value)
        {
            _disposableHelper = new UnmanagedDisposableHelper(Dispose_);

            void Dispose_(bool diposing) => this.DisposeImpl(diposing, this.Value);
        }

        #endregion //Constructors

        #region " Public methods "

        void IDisposable.Dispose()
        {
            _disposableHelper.Dispose();
        }

        #endregion //Public methods

        #region " Protected methods "

        protected abstract void DisposeImpl(bool diposing, T value);

        #endregion //Protected methods
    }
}
