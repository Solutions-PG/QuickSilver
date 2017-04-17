using SolutionsPG.QuickSilver.Commons.Helpers;
using System;
using System.Collections.Generic;

namespace SolutionsPG.QuickSilver.Commons.Disposables
{

    public abstract class Resource<T> : IDisposable
    {
        #region " Variables "

        IDisposable _disposableHelper;
        T Value { get; }

        #endregion //Variables

        #region " Constructors "

        protected Resource(T value)
        {
            _disposableHelper = new DisposableHelper(this.Dispose_);
        }

        #endregion //Constructors

        #region " Public methods "

        void IDisposable.Dispose()
        {
            _disposableHelper.Dispose();
        }

        #endregion //Public methods

        #region " Protected methods "

        protected abstract void DisposeImpl(T value);

        #endregion //Protected methods

        #region " Private methods "

        private void Dispose_() => DisposeImpl(this.Value);

        #endregion //Private methods
    }
}
