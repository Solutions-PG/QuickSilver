using SolutionsPG.QuickSilver.Commons.Helpers;
using System;
using System.Collections.Generic;

namespace SolutionsPG.QuickSilver.Commons.Disposables
{

    public abstract class ResourceUnmanaged<T> : IDisposable
    {
        #region " Variables "

        IDisposable _disposableHelper;
        T Value { get; }

        #endregion //Variables

        #region " Constructors "

        protected ResourceUnmanaged(T value)
        {
            _disposableHelper = new DisposableUnmanagedHelper(this.Dispose_);
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

        #region " Private methods "

        private void Dispose_(bool diposing) => DisposeImpl(diposing, this.Value);

        #endregion //Private methods
    }
}
